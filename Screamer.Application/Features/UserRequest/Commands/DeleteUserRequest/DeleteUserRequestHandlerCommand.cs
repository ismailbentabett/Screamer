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

        public DeleteUserRequestHandlerCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserRequestCommand request, CancellationToken cancellationToken)
        {

            var UsertoDelete = await
                  _userRepository.GetUserByIdAsync(request.Id);

            // verify that record exists
            if (UsertoDelete == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), request.Id);
            }

            // remove from database
            await _userRepository.Delete(UsertoDelete);

            // retun record id
            return Unit.Value;
        }
    }
}