using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostsByCategoryRequest
{
    public class GetPostsByCategoryRequestHandlerQuery
        : IRequestHandler<GetPostsByCategoryRequestQuery, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetPostsByCategoryRequestHandlerQuery(
            IPostRepository postRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<PostDto>> Handle(
            GetPostsByCategoryRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var posts = await _uow.PostRepository.GetPostsByCategory(
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

            var data = _mapper.Map<List<PostDto>>(posts);

            return data;
        }
    }
}
