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

        public MessageHub(IUnitOfWork uow, IMapper mapper, IHubContext<PresenceHub> presenceHub)
        {
            _uow = uow;
            _presenceHub = presenceHub;
            _mapper = mapper;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var otherUser = httpContext.Request.Query["user"];

            var groupName = GetGroupName(
                Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                otherUser
            );
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            var group = await AddToGroup(groupName);

            await Clients.Group(groupName).SendAsync("UpdatedGroup", group);

            var messages = await _uow.MessageRepository.GetMessageThreadRealTime(
                Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                otherUser
            );

            var changes = _uow.HasChanges();

            if (_uow.HasChanges())
                await _uow.Complete();

            await Clients.Caller.SendAsync("ReceiveMessageThread", messages);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var group = await RemoveFromMessageGroup();
            await Clients.Group(group.Name).SendAsync("UpdatedGroup");
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(CreateMessageDto createMessageDto)
        {
            var userId = createMessageDto.userId;

            if (userId == createMessageDto.RecipientId.ToLower())
                throw new HubException("You cannot send messages to yourself");

            var sender = await _uow.UserRepository.GetUserByIdAsync(userId);
            var recipient = await _uow.UserRepository.GetUserByIdAsync(
                createMessageDto.RecipientId
            );

            if (recipient == null)
                throw new HubException("Not found user");

            var message = new Message
            {
                Sender = sender,
                Recipient = recipient,
                SenderId = sender.Id,
                RecipientId = recipient.Id,
                Content = createMessageDto.Content
            };

            var groupName = GetGroupName(sender.Id, recipient.Id);

            var group = await _uow.MessageRepository.GetMessageGroup(groupName);

            if (group.Connections.Any(x => x.UserId == recipient.Id))
            {
                message.DateRead = DateTime.UtcNow;
            }
            else
            {
                var connections = await PresenceTracker.GetConnectionsForUser(recipient.Id);
                if (connections != null)
                {
                    await _presenceHub.Clients
                        .Clients(connections)
                        .SendAsync(
                            "NewMessageReceived",
                            new { userId = sender.Id, Id = sender.Id }
                        );
                }
            }

            _uow.MessageRepository.AddMessage(message);

            if (await _uow.Complete())
            {
                await Clients
                    .Group(groupName)
                    .SendAsync("NewMessage", _mapper.Map<MessageDto>(message));
            }
        }

        private string GetGroupName(string caller, string other)
        {
            var stringCompare = string.CompareOrdinal(caller, other) < 0;
            return stringCompare ? $"{caller}-{other}" : $"{other}-{caller}";
        }

        private async Task<Group> AddToGroup(string groupName)
        {
            var group = await _uow.MessageRepository.GetMessageGroup(groupName);
            var connection = new Connection(
                Context.ConnectionId,
                Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            );

            if (group == null)
            {
                group = new Group(groupName);
                _uow.MessageRepository.AddGroup(group);
            }

            group.Connections.Add(connection);

            if (await _uow.Complete())
                return group;

            throw new HubException("Failed to add to group");
        }

        private async Task<Group> RemoveFromMessageGroup()
        {
            var group = await _uow.MessageRepository.GetGroupForConnection(Context.ConnectionId);
            var connection = group.Connections.FirstOrDefault(
                x => x.ConnectionId == Context.ConnectionId
            );
            _uow.MessageRepository.RemoveConnection(connection);

            if (await _uow.Complete())
                return group;

            throw new HubException("Failed to remove from group");
        }
    }
}
