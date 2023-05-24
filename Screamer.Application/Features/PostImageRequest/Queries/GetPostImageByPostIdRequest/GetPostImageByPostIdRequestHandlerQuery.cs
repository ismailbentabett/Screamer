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

namespace Screamer.Application.Features.postImageRequest.Queries
{
    public class GetPostImageByPostIdRequestHandlerQuery
        : IRequestHandler<GetPostImageByPostIdRequestQuery, List<PostImageDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetPostImageByIdRequestHandlerQuery> _logger;

        public GetPostImageByPostIdRequestHandlerQuery(
            IPostRepository postRepository,
            IMapper mapper,
            IAppLogger<GetPostImageByIdRequestHandlerQuery> logger
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<PostImageDto>> Handle(
            GetPostImageByPostIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var postImage = await _postRepository.GetPostImageByPostIdAsync(request.postId);
            _logger.LogInformation("GetPostImageByIdRequestHandlerQuery called");
            return _mapper.Map<List<PostImageDto>>(postImage);
        }
    }
}
