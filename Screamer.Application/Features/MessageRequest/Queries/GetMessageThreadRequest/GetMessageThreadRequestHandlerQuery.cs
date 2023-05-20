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
    public class GetMessageThreadRequestHandlerQuery : IRequestHandler<
        GetMessageThreadRequestQuery,
        List<MessageDto>
    >
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        private readonly IAppLogger<GetMessageThreadRequestQuery> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;


        public GetMessageThreadRequestHandlerQuery(IMessageRepository messageRepository, IMapper mapper,
            IAppLogger<GetMessageThreadRequestQuery> logger,
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



        async Task<List<MessageDto>> IRequestHandler<GetMessageThreadRequestQuery, List<MessageDto>>.Handle(GetMessageThreadRequestQuery request, CancellationToken cancellationToken)
        {

            var messages = await _uow.MessageRepository.GetMessageThread(
                request.userId,
                request.currentUserId

            );


            return _mapper.Map<
                           List<MessageDto>
                       >(messages);
        }
    }
}