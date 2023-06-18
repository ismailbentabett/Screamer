using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.NotificationRequest.Queries.GetNotificationByIdRequest
{
    public class GetNotificationByIdRequestHandlerQuery
        : IRequestHandler<GetNotificationByIdRequestQuery, NotificationDto>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IAppLogger<GetNotificationByIdRequestHandlerQuery> _logger;

        private readonly INotificationRepository _notification;

        public GetNotificationByIdRequestHandlerQuery(
            IMapper mapper,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor,
            IAppLogger<GetNotificationByIdRequestHandlerQuery> logger,
            INotificationRepository notification
        )
        {
            _mapper = mapper;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _notification = notification;
        }

        public Task<NotificationDto> Handle(
            GetNotificationByIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var notification = _notification.GetByIdAsync(request.NotificationId);

            return Task.FromResult(_mapper.Map<NotificationDto>(notification));
        }
    }
}
