using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.PostRequest.Commands.UpdateUserRequest;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest
{
    public class UpdateUserRequestHandlerCommand :
    IRequestHandler<
        UpdateUserRequestCommand,
        Unit
    >
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserRequestHandlerCommand(IUserRepository postRepository, IMapper mapper)
        {
            _userRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserRequestCommand request, CancellationToken cancellationToken)
        {


            var user = await _userRepository.GetUserByIdAsync(request.Id);

            if (user == null)
            {
                throw new Exception($"user with ID {request.Id} not found.");
            }

            var userInputDto = _mapper.Map<UserDto>(request);


            _mapper.Map(userInputDto, user, typeof(UserDto), typeof(ApplicationUser));

            await _userRepository.Update(user);

            return Unit.Value;


        }
    }
}