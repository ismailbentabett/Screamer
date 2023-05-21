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
using Screamer.Application.Helpers;
using Screamer.Presistance.Repositories;

namespace Screamer.Application.Features.MessageRequest
{
    public class GetMessageThreadRequestHandlerQuery
        : IRequestHandler<GetMessageThreadRequestQuery, List<MessageDto>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAppLogger<GetMessagesForUserRequestQuery> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetMessageThreadRequestHandlerQuery(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IAppLogger<GetMessagesForUserRequestQuery> logger,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        async Task<List<MessageDto>> IRequestHandler<
            GetMessageThreadRequestQuery,
            List<MessageDto>
        >.Handle(GetMessageThreadRequestQuery request, CancellationToken cancellationToken)
        {
            var messages = await _unitOfWork.MessageRepository.GetMessageThread(
                request.userId,
                request.currentUserId,
                request.messageParams
            );

            var messageDtos = _mapper.Map<List<MessageDto>>(messages);
            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(
                new PaginationHeader(
                    messages.CurrentPage,
                    messages.PageSize,
                    messages.TotalCount,
                    messages.TotalPages
                )
            );
            return messageDtos;
        }
    }
}
