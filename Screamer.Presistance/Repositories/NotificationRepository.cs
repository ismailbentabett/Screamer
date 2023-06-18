using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Helpers;
using Screamer.Domain.Entities;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ScreamerDbContext context)
            : base(context) { }

        public async Task<PagedList<Notification>> GetNotificationsByUserId(
            NotificationParams postParams
        )
        {
            var query = _context.Notifications.AsQueryable();

            query = query.Where(n => n.NotificationRoomId == postParams.NotificationRoomId);

            return await PagedList<Notification>.CreateAsync(
                query,
                postParams.PageNumber,
                postParams.PageSize
            );
        }
    }
}
