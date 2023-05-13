
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.PostRequest.Queries;

namespace Screamer.Application.Features.UserRequest.Queries.GetUsersRequest{
    public class GetUsersRequestHandlerQuery : IRequestHandler<
        GetUsersRequestQuery,
        List<UserDto>
    >
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;


        public GetUsersRequestHandlerQuery(IUserRepository userRepository, IMapper mapper   )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUsersRequestQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersAsync();
            var data = _mapper.Map<List<UserDto>>(users);

            return data;
        }
    }
}