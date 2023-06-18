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
using Screamer.Application.Features.NotificationRequest.Queries.GetNotificationByIdRequest;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.NotificationRequest.Queries.GetNotificationsByUserIdRequest
{
    public class GetNotificationsByUserIdRequestHandlerQuery
        : IRequestHandler<GetNotificationsByUserIdRequestQuery, List<NotificationDto>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IAppLogger<GetNotificationByIdRequestHandlerQuery> _logger;

        private readonly INotificationRepository _notification;

        public GetNotificationsByUserIdRequestHandlerQuery(
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

        public async Task<List<NotificationDto>> Handle(
            GetNotificationsByUserIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var notifications = await _uow.NotificationRepository.GetNotificationsByUserId(
                request.notificationParams
            );

            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(
                new PaginationHeader(
                    notifications.CurrentPage,
                    notifications.PageSize,
                    notifications.TotalCount,
                    notifications.TotalPages
                )
            );

            var data = _mapper.Map<List<NotificationDto>>(notifications);

            return _mapper.Map<List<NotificationDto>>(data);
        }
    }
}
