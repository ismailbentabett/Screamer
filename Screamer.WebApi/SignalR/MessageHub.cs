using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Entities;
using Screamer.WebApi.SignalR;

namespace Screamer.WebApi
{
    [Authorize]
    public class MessageHub : Hub
    {
        private readonly IMapper _mapper;
        private readonly IHubContext<PresenceHub> _presenceHub;
        private readonly IUnitOfWork _uow;

        //logger
        private readonly ILogger<MessageHub> _logger;

        public MessageHub(
            IUnitOfWork uow,
            IMapper mapper,
            IHubContext<PresenceHub> presenceHub,
            ILogger<MessageHub> logger
        )
        {
            _uow = uow;
            _presenceHub = presenceHub;
            _mapper = mapper;
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var Room = httpContext.Request.Query["room"];

            await Clients.Caller.SendAsync("Room", Room);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string roomId, string userId, string otherUserId, string message)
        {
            // Save the message to the database

            await Clients
                .Group(roomId.ToString())
                .SendAsync("ReceiveMessage", roomId, userId, otherUserId, message);
            _logger.LogInformation($"Message sent from {userId} to {otherUserId} in room {roomId}");
        }

        public async Task JoinRoom(string roomId)
        {
    
        await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        await Clients.Group(roomId).SendAsync("JoinRoom", roomId);
 
        await Clients.Client(Context.ConnectionId).SendAsync("JoinRoom", roomId);
            
        }

        public async Task LeaveRoom(string roomId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());

            // Remove the user from the database

            await Clients.Group(roomId.ToString()).SendAsync("UserDisconnected", roomId);
        }

        public async Task Typing(int roomId, string userId)
        {
            await Clients.Group(roomId.ToString()).SendAsync("UserTyping", userId);
        }
    }
}
