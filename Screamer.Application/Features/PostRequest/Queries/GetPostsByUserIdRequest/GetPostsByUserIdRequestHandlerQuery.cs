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

namespace Screamer.Application.Features.PostRequest.Queries.GetPostRequest
{
    public class GetPostByUserIdRequestHandlerQuery : IRequestHandler<
        GetPostByUserIdRequestQuery, PostDto
     >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetPostByUserIdRequestHandlerQuery> _logger;

        private readonly IUnitOfWork _uow;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetPostByUserIdRequestHandlerQuery(IPostRepository postRepository, IMapper mapper,
            IAppLogger<GetPostByUserIdRequestHandlerQuery> logger,
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


        public async Task<PostDto> Handle(GetPostByUserIdRequestQuery request, CancellationToken cancellationToken)
        {
            var post = await _uow.PostRepository.GetPostsByUserId(request.UserId, request.postParams);

            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(new PaginationHeader(post.CurrentPage, post.PageSize,
              post.TotalCount, post.TotalPages));

            var data = _mapper.Map<PostDto>(post);

            return data;
        }
    }
}