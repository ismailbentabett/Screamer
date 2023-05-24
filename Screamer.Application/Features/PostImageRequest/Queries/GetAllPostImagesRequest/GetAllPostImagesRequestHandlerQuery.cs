using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.postImageRequest.Queries
{
    public class GetAllPostImagesRequestHandlerQuery
        : IRequestHandler<GetAllPostImagesRequestQuery, IEnumerable<PostImageDto>>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetAllPostImagesRequestQuery> _logger;

        public GetAllPostImagesRequestHandlerQuery(
            IPostImageRepository postImageRepository,
            IMapper mapper,
            IAppLogger<GetAllPostImagesRequestQuery> logger
        )
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<PostImageDto>> Handle(
            GetAllPostImagesRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var postImages = await _postImageRepository.GetAllAsync();
            _logger.LogInformation("GetAllPostImagesRequestQuery called");
            return _mapper.Map<IEnumerable<PostImageDto>>(postImages);
        }
    }
}
