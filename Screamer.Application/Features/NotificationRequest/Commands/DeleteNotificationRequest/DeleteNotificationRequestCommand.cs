using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.NotificationRequest.Commands.DeleteNotificationRequest
{
    public class DeleteNotificationRequestCommand : IRequest<Unit> { }
}
