using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.MessageRequest
{
    public class GetMessagesForUserRequestHandlerQuery : IRequestHandler<
        GetMessagesForUserRequestQuery, 
        IEnumerable<MessageDto>
    >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetMessagesForUserRequestQuery> _logger; 

        public GetMessagesForUserRequestHandlerQuery(IPostRepository postRepository, IMapper mapper , 
            IAppLogger<GetMessagesForUserRequestQuery> logger
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }

    

        Task<IEnumerable<MessageDto>> IRequestHandler<GetMessagesForUserRequestQuery, IEnumerable<MessageDto>>.Handle(GetMessagesForUserRequestQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}