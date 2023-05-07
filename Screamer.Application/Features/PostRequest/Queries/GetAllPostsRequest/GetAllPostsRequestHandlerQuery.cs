using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetAllPostsRequest
{
    public class GetAllPostsRequestHandlerQuery : IRequestHandler<
        GetAllPostsRequestQuery, 
        IEnumerable<PostDto>
    >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetAllPostsRequestHandlerQuery> _logger; 

        public GetAllPostsRequestHandlerQuery(IPostRepository postRepository, IMapper mapper , 
            IAppLogger<GetAllPostsRequestHandlerQuery> logger
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PostDto>> Handle(GetAllPostsRequestQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllAsync();
            _logger.LogInformation("GetAllPostsRequestHandlerQuery called");
            return _mapper.Map<IEnumerable<PostDto>>(posts);
        }
    }
}