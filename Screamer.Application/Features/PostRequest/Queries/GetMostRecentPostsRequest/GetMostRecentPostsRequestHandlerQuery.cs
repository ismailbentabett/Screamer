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
using Screamer.Application.Features.PostRequest.Queries.GetAllPostsRequest;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.PostRequest.Queries.GetMostRecentPostsRequest
{
    public class GetMostRecentPostsRequestHandlerQuery
        : IRequestHandler<GetMostRecentPostsRequestQuery, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        private readonly IHttpContextAccessor _httpContextAccessor;

        GetMostRecentPostsRequestHandlerQuery(
            IPostRepository postRepository,
            IMapper mapper,
            IAppLogger<GetAllPostsRequestHandlerQuery> logger,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _logger = logger;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        private readonly IAppLogger<GetAllPostsRequestHandlerQuery> _logger;

        public async Task<List<PostDto>> Handle(
            GetMostRecentPostsRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var posts = await _uow.PostRepository.GetMostRecentPosts(request.postParams);

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

            var data = _mapper.Map<List<PostDto>>(posts);

            return data;
        }
    }
}
