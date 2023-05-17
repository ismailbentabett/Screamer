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

namespace Screamer.Application.Features.PostRequest.Queries.GetAllPostsRequest
{
    public class GetAllPostsRequestHandlerQuery : IRequestHandler<
        GetAllPostsRequestQuery,
        List<PostDto>
    >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

                private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IAppLogger<GetAllPostsRequestHandlerQuery> _logger;



        public GetAllPostsRequestHandlerQuery(IPostRepository postRepository, IMapper mapper,
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

        public async Task<List<PostDto>> Handle(GetAllPostsRequestQuery request, CancellationToken cancellationToken)
        {
          
            var posts = await _uow.PostRepository.GetAllAsync(request.postParams);

            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(new PaginationHeader(posts.CurrentPage, posts.PageSize,
              posts.TotalCount, posts.TotalPages));

            var data = _mapper.Map<List<PostDto>>(posts);

            return data;
        }
    }
}