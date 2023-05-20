
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Domain.Entities;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class MessageRepository  :  IMessageRepository , IGenericRepository<Message>
    {
        private readonly ScreamerDbContext _context;
        private readonly IMapper _mapper;

        public MessageRepository(ScreamerDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddGroup(Group group)
        {
            _context.Groups.Add(group);
        }

        public void AddMessage(Message message)
        {
            _context.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _context.Messages.Remove(message);
        }

        public async Task<Connection> GetConnection(string connectionId)
        {
            return await _context.Connections.FindAsync(connectionId);
        }

        public async Task<Group> GetGroupForConnection(string connectionId)
        {
            return await _context.Groups
                .Include(x => x.Connections)
                .Where(x => x.Connections.Any(c => c.ConnectionId == connectionId))
                .FirstOrDefaultAsync();
        }

        public async Task<Message> GetMessage(int id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<Group> GetMessageGroup(string groupName)
        {
            return await _context.Groups
                .Include(x => x.Connections)
                .FirstOrDefaultAsync(x => x.Name == groupName);
        }

        public async Task<PagedList<MessageDto>> GetMessagesForUser(MessageParams messageParams)
        {
            var query = _context.Messages
                .OrderByDescending(x => x.MessageSent)
                .AsQueryable();

            query = messageParams.Container switch
            {
                "Inbox" => query.Where(u => u.RecipientId == messageParams.userId 
                    && u.RecipientDeleted == false),
                "Outbox" => query.Where(u => u.SenderId == messageParams.userId 
                    && u.SenderDeleted == false),
                _ => query.Where(u => u.RecipientId == messageParams.userId 
                    && u.RecipientDeleted == false && u.DateRead == null)
            };

            var messages = query.ProjectTo<MessageDto>(_mapper.ConfigurationProvider);

            return await PagedList<MessageDto>
                .CreateAsync(messages, messageParams.PageNumber, messageParams.PageSize);
        }

        public async Task<IEnumerable<MessageDto>> GetMessageThread(string currentUserId, string recipientUserId)
        {
            var query = _context.Messages
                .Where(
                    m => m.RecipientId == recipientUserId && m.RecipientDeleted == false &&
                    m.SenderId == recipientUserId ||
                    m.RecipientId == recipientUserId && m.SenderDeleted == false &&
                    m.SenderId == currentUserId
                )
                .OrderBy(m => m.MessageSent)
                .AsQueryable();


            var unreadMessages = query.Where(m => m.DateRead == null 
                && m.RecipientId == currentUserId).ToList();

            if (unreadMessages.Any())
            {
                foreach (var message in unreadMessages)
                {
                    message.DateRead = DateTime.UtcNow;
                }
            }

            return await query.ProjectTo<MessageDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public void RemoveConnection(Connection connection)
        {
            _context.Connections.Remove(connection);
        }

        Task<Message> IGenericRepository<Message>.AddAsync(Message entity)
        {
            throw new NotImplementedException();
        }

        Task<Message> IGenericRepository<Message>.DeleteAsync(Message entity)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Message>> IGenericRepository<Message>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Message> IGenericRepository<Message>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Message> IGenericRepository<Message>.UpdateAsync(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}