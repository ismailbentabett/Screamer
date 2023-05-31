using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.UserRequest.Commands.DeleteUserRequest;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Commands.DeletePostRequest
{
    public class DeleteUserRequestHandlerCommand : IRequestHandler<DeleteUserRequestCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        private readonly IAlgoliaService _algoliaService;

        public DeleteUserRequestHandlerCommand(
            IUserRepository userRepository,
            IUnitOfWork uow,
            IMapper mapper,
            IAlgoliaService algoliaService
        )
        {
            _userRepository = userRepository;
            _uow = uow;
            _mapper = mapper;
            _algoliaService = algoliaService;
        }

        public async Task<Unit> Handle(
            DeleteUserRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.Id);

            if (user == null)
            {
                throw new Exception($"user with ID {request.Id} not found.");
            }

            await _uow.UserRepository.Delete(user);

            if (await _uow.Complete())
            {
                var users = await _uow.UserRepository.GetAllAsync();
                var userSearchDto = _mapper.Map<IEnumerable<UserSearchResult>>(users);

                await _algoliaService.AddAllUsersToIndex("user", userSearchDto);

                return Unit.Value;
            }

            throw new Exception($"Problem saving changes for user with ID {request.Id}.");
        }
    }
}
