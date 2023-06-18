using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.NotificationRequest.Commands.UpdateNotificationRequest
{
    public class UpdateNotificationRequestHandlerCommand
        : IRequestHandler<UpdateNotificationRequestCommand, Unit>
    {
        public Task<Unit> Handle(
            UpdateNotificationRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
