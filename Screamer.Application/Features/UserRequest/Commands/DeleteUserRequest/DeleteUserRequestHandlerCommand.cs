using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Features.UserRequest.Commands.DeleteUserRequest;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Commands.DeletePostRequest
{
    public class DeleteUserRequestHandlerCommand :
    IRequestHandler
    <
        DeleteUserRequestCommand,
        Unit
        >
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _uow;



        public DeleteUserRequestHandlerCommand(IUserRepository userRepository,
            IUnitOfWork uow
        )
        {
            _userRepository = userRepository;
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteUserRequestCommand request, CancellationToken cancellationToken)
        {

            var user = await _uow.UserRepository.GetUserByIdAsync(request.Id);

            if (user == null)
            {
                throw new Exception($"user with ID {request.Id} not found.");
            }

            await _uow.UserRepository.Delete(user);

            if (await _uow.Complete()) return
                Unit.Value;

            throw new Exception($"Problem saving changes for user with ID {request.Id}.");



        }
    }
}