using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.MessageRequest;
using Screamer.Domain.Entities;
using Screamer.WebApi.SignalR;

namespace Screamer.WebApi.SignalR
{
    public class NotificationHub : Hub
    {
        private readonly IMapper _mapper;
        private readonly IHubContext<PresenceHub> _presenceHub;
        private readonly IUnitOfWork _uow;

        //logger
        private readonly ILogger<MessageHub> _logger;
        private readonly IMediator _mediator;

        public NotificationHub(
            IUnitOfWork uow,
            IMapper mapper,
            IHubContext<PresenceHub> presenceHub,
            ILogger<MessageHub> logger,
            IMediator mediator
        )
        {
            _uow = uow;
            _presenceHub = presenceHub;
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
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

        public async Task SendNotification(
            string roomId,
            CreateNotificationDto createNotificationDto
        )
        {
            // Save the message to the database

            await Clients
                .Group(roomId.ToString())
                .SendAsync(
                    "ReceiveMessage",
                    roomId,
                    createNotificationDto.senderId,
                    createNotificationDto.recieverId,
                    createNotificationDto.Message
                );

            /*   var command = new CreateMessageRequestCommand
              {
                  createMessageDto = createMessageDto,
                  userId = createMessageDto.userId
              };
  
              await _mediator.Send(command); */
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

            await Clients.Group(roomId.ToString()).SendAsync("UserDisconnected", roomId);
        }
    }
}
