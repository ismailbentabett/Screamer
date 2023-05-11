using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.AvatarRequest.Queries.GetAllAvatarsRequest
{
    public class GetAllAvatarsRequestHandlerQuery : IRequestHandler<
        GetAllAvatarsRequestQuery, 
        IEnumerable<AvatarDto>
    >
    {
        private readonly IAvatarRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetAllAvatarsRequestHandlerQuery> _logger; 

        public GetAllAvatarsRequestHandlerQuery(IAvatarRepository postRepository, IMapper mapper , 
            IAppLogger<GetAllAvatarsRequestHandlerQuery> logger
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AvatarDto>> Handle(GetAllAvatarsRequestQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync();
            _logger.LogInformation("GetAllAvatarsRequestHandlerQuery called");
            return _mapper.Map<IEnumerable<AvatarDto>>(posts);
        }
    }
}