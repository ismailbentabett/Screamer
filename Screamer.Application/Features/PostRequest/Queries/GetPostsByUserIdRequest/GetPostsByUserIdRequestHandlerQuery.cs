using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostRequest
{
    public class GetPostByUserIdRequestHandlerQuery : IRequestHandler<
        GetPostByUserIdRequestQuery, PostDto
     >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetPostByUserIdRequestHandlerQuery> _logger; 

        public GetPostByUserIdRequestHandlerQuery(IPostRepository postRepository, IMapper mapper , 
            IAppLogger<GetPostByUserIdRequestHandlerQuery> logger
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }
      

        public async Task<PostDto> Handle(GetPostByUserIdRequestQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostsByUserId(request.UserId);
            _logger.LogInformation("GetPostByUserIdRequestHandlerQuery called");
            return _mapper.Map<PostDto>(post);
        }
    }
}