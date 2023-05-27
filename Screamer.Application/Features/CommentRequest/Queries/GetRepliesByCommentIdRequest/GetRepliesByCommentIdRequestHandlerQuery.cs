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

namespace Screamer.Application.Features.CommentRequest.Queries.GetRepliesByCommentIdRequest
{
    public class GetRepliesByCommentIdRequestHandlerQuery
        : IRequestHandler<GetRepliesByCommentIdRequestQuery, List<CommentDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetRepliesByCommentIdRequestHandlerQuery> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetRepliesByCommentIdRequestHandlerQuery(
            IUnitOfWork uow,
            IMapper mapper,
            IAppLogger<GetRepliesByCommentIdRequestHandlerQuery> logger,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<CommentDto>> Handle(
            GetRepliesByCommentIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var replies = await _uow.CommentRepository.GetRepliesByCommentId(request.commentParams);
            _logger.LogInformation(
                $"{nameof(GetRepliesByCommentIdRequestHandlerQuery)} "
                    + $"returned {replies.Count} replies"
            );

            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;

            Response.AddPaginationHeader(
                new PaginationHeader(
                    replies.CurrentPage,
                    replies.PageSize,
                    replies.TotalCount,
                    replies.TotalPages
                )
            );

            var data = _mapper.Map<List<CommentDto>>(replies);

            return data;
        }
    }
}
