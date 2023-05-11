using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.UserRequest.Queries.GetUsersRequest{
    public class GetAllPostsRequestHandlerQuery : IRequestHandler<
        GetUsersRequestQuery,
        IEnumerable<UserDto>
    >
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetUsersRequestQuery> _logger;

        public GetAllPostsRequestHandlerQuery(IUserRepository userRepository, IMapper mapper,
            IAppLogger<GetUsersRequestQuery> logger
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetUsersRequestQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetUsersAsync();
            _logger.LogInformation("GetAllPostsRequestHandlerQuery called");
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}