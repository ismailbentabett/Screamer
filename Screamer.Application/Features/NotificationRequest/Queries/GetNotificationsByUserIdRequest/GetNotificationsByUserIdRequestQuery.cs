using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.NotificationRequest.Queries.GetNotificationsByUserIdRequest
{
    public class GetNotificationsByUserIdRequestQuery : IRequest<List<NotificationDto>>
    {
        public NotificationParams notificationParams { get; set; }
    }
}
