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
    public class GetMessagesForUserRequestHandlerQuery : IRequestHandler<
        GetMessagesForUserRequestQuery,
        IEnumerable<MessageDto>
    >
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        private readonly IAppLogger<GetMessagesForUserRequestQuery> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;


        public GetMessagesForUserRequestHandlerQuery(IMessageRepository messageRepository, IMapper mapper,
            IAppLogger<GetMessagesForUserRequestQuery> logger,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _logger = logger;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }



        async Task<IEnumerable<MessageDto>> IRequestHandler<GetMessagesForUserRequestQuery, IEnumerable<MessageDto>>.Handle(GetMessagesForUserRequestQuery request, CancellationToken cancellationToken)
        {
            request.messageParams.Username = request.userName;

            var messages = await _uow.MessageRepository.GetMessagesForUser(request.messageParams);
            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(new PaginationHeader(messages.CurrentPage, messages.PageSize,
                messages.TotalCount, messages.TotalPages));

            return messages;
        }
    }
}