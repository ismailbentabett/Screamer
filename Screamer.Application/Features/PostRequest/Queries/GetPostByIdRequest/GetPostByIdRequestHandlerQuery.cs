using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostRequest
{
    public class GetPostByIdRequestHandlerQuery : IRequestHandler<
        GetPostByIdRequestQuery, PostDto
     >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetPostByIdRequestHandlerQuery> _logger; 

        public GetPostByIdRequestHandlerQuery(IPostRepository postRepository, IMapper mapper , 
            IAppLogger<GetPostByIdRequestHandlerQuery> logger
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PostDto> Handle(GetPostByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);
            _logger.LogInformation("GetPostByIdRequestHandlerQuery called");
            return _mapper.Map<PostDto>(post);
        }
    }
}