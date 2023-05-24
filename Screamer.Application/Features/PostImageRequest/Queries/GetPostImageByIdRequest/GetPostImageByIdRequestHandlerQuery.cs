using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.AvatarRequest.Queries.GetAvatarByIdRequest;

namespace Screamer.Application.Features.AvatarRequest.Queries.GetAvatarRequest
{
    public class GetAvatarByIdRequestHandlerQuery : IRequestHandler<
        GetAvatarByIdRequestQuery, AvatarDto
     >
    {
        private readonly IAvatarRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetAvatarByIdRequestHandlerQuery> _logger; 

        public GetAvatarByIdRequestHandlerQuery(IAvatarRepository postRepository, IMapper mapper , 
            IAppLogger<GetAvatarByIdRequestHandlerQuery> logger
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<AvatarDto> Handle(GetAvatarByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);
            _logger.LogInformation("GetAvatarByIdRequestHandlerQuery called");
            return _mapper.Map<AvatarDto>(post);
        }
    }
}