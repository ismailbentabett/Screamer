using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Domain.Entities;

namespace Screamer.Presistance.Repositories
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
        void AddMessage(Message message);
        void DeleteMessage(Message message);
        Task<Message> GetMessage(int id);
        Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams);
        Task<PagedList<MessageDto>> GetMessageThread(
            string currentUserId,
            string recipientUserId,
            MessageParams messageParams
        );
        Task<PagedList<Domain.Entities.ChatRoom>> GetUserChatRooms(
            string userId,
            MessageParams messageParams
        );

        Task<ChatRoom> GetChatRoomById(int id);
        Task<Domain.Entities.ChatRoom> GetChatRoomForUsers(string userId, string recipientId);
        void AddChatRoom(Domain.Entities.ChatRoom chatRoom);
        void AddGroup(Group group);
        void RemoveConnection(Connection connection);
        Task<Connection> GetConnection(string connectionId);
        Task<Group> GetMessageGroup(string groupName);
        Task<Group> GetGroupForConnection(string connectionId);
        Task<CancellationToken> GetMessageThreadRealTime(string value, StringValues otherUser);
        Task<ChatRoom> CreateRoom(
            ChatRoomUser SenderChatRoomUser,
            ChatRoomUser RecipientChatRoomUser,
            ChatRoom chatRoom
        );
    }
}
