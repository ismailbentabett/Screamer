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

namespace Screamer.Application.Features.CommentRequest.Queries.GetCommentsByPostIdRequest
{
    public class GetCommentsByPostIdRequestHandlerQuery
        : IRequestHandler<GetCommentsByPostIdRequestQuery, List<CommentDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetCommentsByPostIdRequestHandlerQuery> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetCommentsByPostIdRequestHandlerQuery(
            IUnitOfWork uow,
            IMapper mapper,
            IAppLogger<GetCommentsByPostIdRequestHandlerQuery> logger,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CommentDto>> Handle(
            GetCommentsByPostIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var comments = await _uow.CommentRepository.GetPostComments(request.commentParams);

            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;

            Response.AddPaginationHeader(
                new PaginationHeader(
                    comments.CurrentPage,
                    comments.PageSize,
                    comments.TotalCount,
                    comments.TotalPages
                )
            );

            var data = _mapper.Map<List<CommentDto>>(comments);

            return data;
        }
    }
}
