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
    public class GetUserFollowsRequestHandlerQuery : IRequestHandler<
        GetUserFollowsRequestQuery, List<FollowDto>
     >
    {


        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;


        public GetUserFollowsRequestHandlerQuery(IMapper mapper,

            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _mapper = mapper;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<List<FollowDto>> Handle(GetUserFollowsRequestQuery request, CancellationToken cancellationToken)
        {
            request.followParams.UserId = request.userId;

            var users = await _uow.FollowRepository.GetUserFollows(request.followParams);
            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage,
                users.PageSize, users.TotalCount, users.TotalPages));

            return
                _mapper.Map<List<FollowDto>>(users);

        }
    }
}