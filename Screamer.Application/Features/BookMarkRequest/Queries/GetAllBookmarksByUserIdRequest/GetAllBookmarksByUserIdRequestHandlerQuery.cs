using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.BookMarkRequest
{
    public class GetAllBookmarksByUserIdRequestHandlerQuery
        : IRequestHandler<GetAllBookmarksByUserIdRequestQuery, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAlgoliaService _algoliaService;

        public GetAllBookmarksByUserIdRequestHandlerQuery(
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
            GetAllBookmarksByUserIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var currentUser = await _uow.UserRepository.GetUserByIdAsync(request.postParams.UserId);
            if (currentUser == null)
                throw new NotFoundException(nameof(ApplicationUser), request.postParams.UserId);

            var posts = await _uow.BookMarkRepository.GetAllBookmarksByUserIdRequest(
                request.postParams
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
