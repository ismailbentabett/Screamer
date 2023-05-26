using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostsByFollowingRequest
{
    public class GetPostsByFollowingRequestHandlerQuery
        : IRequestHandler<GetPostsByFollowingRequestQuery, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAppLogger<GetPostsByFollowingRequestQuery> _logger;

        GetPostsByFollowingRequestHandlerQuery(
            IPostRepository postRepository,
            IMapper mapper,
            IAppLogger<GetPostsByFollowingRequestQuery> logger,
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

        public async Task<List<PostDto>> Handle(
            GetPostsByFollowingRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            //check if current user exist
            var currentUser = await _uow.UserRepository.GetUserByIdAsync(request.userId);
            if (currentUser == null)
                throw new NotFoundException(nameof(ApplicationUser), request.userId);

            var posts = await _postRepository.GetPostsByFollowing(
                request.userId,
                request.recommendationParams
            );

            var postsDto = _mapper.Map<List<PostDto>>(posts);

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

            return postsDto;
        }
    }
}
