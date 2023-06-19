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
            string Message,
            string Type,
            int ChatRoomId,
            string NotificationRoomId,
            int PostId,
            string SenderId,
            string RecieverId,
            int CommentId,
            int ReplyId,
            int ReactionId,
            int TagId,
            int MentionId,
            bool IsRead
        )
        {
            var rooms = await _uow.UserRepository.GetFollowersIdsAsync(roomId);
            var user = await _uow.UserRepository.GetUserByIdAsync(SenderId);
            var userData = _mapper.Map<UserDto>(user);
            CreateNotificationDto createMessageDto = new CreateNotificationDto
            {
                Message = Message,
                Type = Type,
                ChatRoomId = ChatRoomId,
                NotificationRoomId = NotificationRoomId,
                PostId = PostId,
                SenderId = SenderId,
                RecieverId = RecieverId,
                CommentId = CommentId,
                ReplyId = ReplyId,
                ReactionId = ReactionId,
                TagId = TagId,
                MentionId = MentionId,
                IsRead = IsRead,
                user = userData
            };
            Console.WriteLine("createMessageDto", createMessageDto);

            switch (Type)
            {
                case "Chat":
                    Console.WriteLine("createMessageDto", createMessageDto);
                    await Clients
                        .Group(RecieverId.ToString())
                        .SendAsync("ReceiveNotification", RecieverId, createMessageDto);
                    break;

                case "Post":
                    foreach (var room in rooms)
                    {
                        await Clients
                            .Group(room.ToString())
                            .SendAsync("ReceiveNotification", room, createMessageDto);
                    }

                    break;

                case "Comment":
                    if (RecieverId != SenderId)
                    {
                        await Clients
                            .Group(RecieverId.ToString())
                            .SendAsync("ReceiveNotification", RecieverId, createMessageDto);
                    }

                    break;

                case "Reply":
                    if (RecieverId != SenderId)
                    {
                        await Clients
                            .Group(RecieverId.ToString())
                            .SendAsync("ReceiveNotification", RecieverId, createMessageDto);
                    }

                    break;
                case "Reaction":
                    if (RecieverId != SenderId)
                    {
                        await Clients
                            .Group(RecieverId.ToString())
                            .SendAsync("ReceiveNotification", RecieverId, createMessageDto);
                    }

                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Notification));
            }

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
