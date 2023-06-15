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

namespace Screamer.Application.Features.UserRequest.Queries.GetTheTopPreformingUsers
{
    public class GetTheTopPreformingUsersHandlerQuery
        : IRequestHandler<GetTheTopPreformingUsersQuery, List<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetTheTopPreformingUsersHandlerQuery(
            IUserRepository userRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<UserDto>> Handle(
            GetTheTopPreformingUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            var users = await _uow.UserRepository.GetTheTopPreformingUsers(request.userParams);

            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(
                new PaginationHeader(
                    users.CurrentPage,
                    users.PageSize,
                    users.TotalCount,
                    users.TotalPages
                )
            );

            var data = _mapper.Map<List<UserDto>>(users);

            return data;
        }
    }
}
