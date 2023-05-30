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
using Screamer.Application.Features.PostRequest.Queries.GetPostByUserIdRequest;
using Screamer.Application.Helpers;
using Screamer.Domain.Common;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostRequest
{
    public class GetPostByUserIdRequestHandlerQuery
        : IRequestHandler<GetPostByUserIdRequestQuery, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetPostByUserIdRequestHandlerQuery> _logger;

        private readonly IUnitOfWork _uow;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlgoliaService _algoliaService;

        public GetPostByUserIdRequestHandlerQuery(
            IPostRepository postRepository,
            IMapper mapper,
            IAppLogger<GetPostByUserIdRequestHandlerQuery> logger,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor,
            IAlgoliaService algoliaService
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
            _algoliaService = algoliaService;
        }

        public async Task<List<PostDto>> Handle(
            GetPostByUserIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var posts = await _uow.PostRepository.GetPostsByUserId(
                request.UserId,
                request.postParams
            );

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
            var data = _mapper.Map<List<Post>>(posts);
            return _mapper.Map<List<PostDto>>(data);
        }
    }
}
