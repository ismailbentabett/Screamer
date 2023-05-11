using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest;

namespace Screamer.Application.Features.UserRequest.Queries.GetUserByUsernameRequest
{
    public class GetUserByUsernameRequestRequestHandlerQuery : IRequestHandler<
        GetUserByUsernameRequestQuery, UserDto
     >
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetUserByUsernameRequestQuery> _logger;

        public GetUserByUsernameRequestRequestHandlerQuery(IUserRepository userRepository, IMapper mapper,
            IAppLogger<GetUserByUsernameRequestQuery> logger
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<UserDto> Handle(GetUserByUsernameRequestQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            _logger.LogInformation("GetUserByUsernameRequestRequestHandlerQuery called");
            return _mapper.Map<UserDto>(user);
        }
    }
}