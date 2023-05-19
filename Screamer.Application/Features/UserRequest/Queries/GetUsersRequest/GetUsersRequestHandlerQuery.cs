
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.PostRequest.Queries;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.UserRequest.Queries.GetUsersRequest
{
    public class GetUsersRequestHandlerQuery : IRequestHandler<
        GetUsersRequestQuery,
        List<UserDto>
    >
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public GetUsersRequestHandlerQuery(IUserRepository userRepository, IMapper mapper,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor
          )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<UserDto>> Handle(GetUsersRequestQuery request, CancellationToken cancellationToken)
        {


            var currentUser = await _uow.UserRepository.GetUserByIdAsync(request.userId);
            request.userParams.userName = currentUser.UserName;
            request.userParams.AvatarUrl = currentUser.AvatarUrl;
            request.userParams.CoverUrl = currentUser.CoverUrl;
            request.userParams.Bio = currentUser.Bio;
            request.userParams.Website = currentUser.Website;
            request.userParams.Birthday = currentUser.Birthday;
            request.userParams.Gender = currentUser.Gender;
            request.userParams.Phone = currentUser.Phone;
            request.userParams.FirstName = currentUser.FirstName;
            request.userParams.LastName = currentUser.LastName;
            request.userParams.CreatedAt = currentUser.CreatedAt;





            if (string.IsNullOrEmpty(request.userParams.Gender))
            {
                request.userParams.Gender = currentUser.Gender == "male" ? "female" : "male";
            }

            var users = await _uow.UserRepository.GetUsersAsync(request.userParams);

            HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage, users.PageSize,
              users.TotalCount, users.TotalPages));

            var data = _mapper.Map<List<UserDto>>(users);

            return data;

        }









    }
}
