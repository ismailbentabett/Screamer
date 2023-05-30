using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.PostRequest.Queries.GetRecommendedPostsRequest
{
    public class GetRecommendedPostsRequestHandlerQuery
        : IRequestHandler<GetRecommendedPostsRequestQuery, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;
        private readonly IAlgoliaService _algoliaService;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetRecommendedPostsRequestHandlerQuery(
            IPostRepository postRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor,
            IAlgoliaService algoliaService
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _algoliaService = algoliaService;
        }

        public async Task<List<PostDto>> Handle(
            GetRecommendedPostsRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var posts = await _uow.PostRepository.GetRecommendedPosts(request.postParams);

            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(
                new PaginationHeader(
                    posts.CurrentPage,
                    posts.PageSize,
                    posts.TotalCount,
                    posts.TotalPages
                )
            );
            await _algoliaService.AddAllPostsToIndex("post", posts);
            var data = _mapper.Map<List<PostDto>>(posts);

            return data;
        }
    }
}
