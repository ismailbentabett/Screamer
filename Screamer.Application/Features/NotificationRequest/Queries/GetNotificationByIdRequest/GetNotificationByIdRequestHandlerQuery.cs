using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.NotificationRequest.Queries.GetNotificationByIdRequest
{
    public class GetNotificationByIdRequestHandlerQuery
        : IRequestHandler<GetNotificationByIdRequestQuery, NotificationDto>
    {
        public Task<NotificationDto> Handle(
            GetNotificationByIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
