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
    public class GetPostImageByIdRequestHandlerQuery
        : IRequestHandler<GetPostImageByIdRequestQuery, PostImageDto>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetPostImageByIdRequestHandlerQuery> _logger;

        public GetPostImageByIdRequestHandlerQuery(
            IPostImageRepository postImageRepository,
            IMapper mapper,
            IAppLogger<GetPostImageByIdRequestHandlerQuery> logger
        )
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PostImageDto> Handle(
            GetPostImageByIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var postImage = await _postImageRepository.GetByIdAsync(request.Id);
            _logger.LogInformation("GetPostImageByIdRequestHandlerQuery called");
            return _mapper.Map<PostImageDto>(postImage);
        }
    }
}
