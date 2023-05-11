using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.AvatarRequest.Queries.GetAvatarByUserIdRequest;

namespace Screamer.Application.Features.AvatarRequest.Queries.GetAvatarRequest
{
    public class GetAvatarByUserIdRequestHandlerQuery : IRequestHandler<
        GetAvatarByUserIdRequestQuery, AvatarDto
     >
    {
        private readonly IAvatarRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetAvatarByUserIdRequestHandlerQuery> _logger; 

        public GetAvatarByUserIdRequestHandlerQuery(IAvatarRepository postRepository, IMapper mapper , 
            IAppLogger<GetAvatarByUserIdRequestHandlerQuery> logger
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }
      

        public async Task<AvatarDto> Handle(GetAvatarByUserIdRequestQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetAvatarsByUserId(request.UserId);
            _logger.LogInformation("GetAvatarByUserIdRequestHandlerQuery called");
            return _mapper.Map<AvatarDto>(post);
        }
    }
}