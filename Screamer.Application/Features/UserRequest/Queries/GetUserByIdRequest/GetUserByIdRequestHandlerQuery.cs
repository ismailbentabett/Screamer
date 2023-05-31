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

namespace Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest
{
    public class GetPostByIdRequestHandlerQuery : IRequestHandler<GetUserByIdRequestQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly IAlgoliaService _algoliaService;
        private readonly IAppLogger<GetUserByIdRequestQuery> _logger;

        public GetPostByIdRequestHandlerQuery(
            IUserRepository userRepository,
            IMapper mapper,
            IAppLogger<GetUserByIdRequestQuery> logger,
            IUnitOfWork uow,
            IAlgoliaService algoliaService
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
            _uow = uow;
            _algoliaService = algoliaService;
        }

        public async Task<UserDto> Handle(
            GetUserByIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _userRepository.GetUserByIdAsync(request.Id);
            _logger.LogInformation("GetUserByIdRequestHandlerQuery called");
            var searchusers = await _uow.UserRepository.GetAllAsync();
            var userSearchDto = _mapper.Map<IEnumerable<UserSearchResult>>(searchusers);
            await _algoliaService.AddAllUsersToIndex("user", userSearchDto);
            return _mapper.Map<UserDto>(user);
        }
    }
}
