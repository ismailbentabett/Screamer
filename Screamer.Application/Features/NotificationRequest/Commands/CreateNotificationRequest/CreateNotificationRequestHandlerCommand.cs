using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.NotificationRequest.Commands.CreateNotificationRequest
{
    public class CreateNotificationRequestHandlerCommand
        : IRequestHandler<CreateNotificationRequestCommand, int>
    {
        public Task<int> Handle(
            CreateNotificationRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
