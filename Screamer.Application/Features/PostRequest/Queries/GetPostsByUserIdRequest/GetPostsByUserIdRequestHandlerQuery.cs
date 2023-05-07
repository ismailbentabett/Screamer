using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
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

        public GetPostByUserIdRequestHandlerQuery(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
      

        public async Task<PostDto> Handle(GetPostByUserIdRequestQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetPostsByUserId(request.UserId);
            return _mapper.Map<PostDto>(post);
        }
    }
}