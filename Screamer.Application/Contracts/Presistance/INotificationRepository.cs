using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Helpers;
using Screamer.Domain.Entities;

namespace Screamer.Application.Contracts.Presistance
{
    public interface INotificationRepository : IGenericRepository<Notification>
    {
        Task<PagedList<Notification>> GetNotificationsByUserId(NotificationParams postParams);
    }
}
