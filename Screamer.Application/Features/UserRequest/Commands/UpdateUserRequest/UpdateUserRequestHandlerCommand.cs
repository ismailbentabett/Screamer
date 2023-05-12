using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<ApplicationUser> _UserManager;

        private readonly IUnitOfWork _uow;


        public UpdateUserRequestHandlerCommand(IUserRepository postRepository, IMapper mapper,
            UserManager<ApplicationUser> usermanager,

            IUnitOfWork uow
        )
        {
            _userRepository = postRepository;
            _mapper = mapper;
            _UserManager = usermanager;
            _uow = uow;
        }

        public async Task<Unit> Handle(UpdateUserRequestCommand request, CancellationToken cancellationToken)
        {


            {
                var user = await _uow.UserRepository.GetUserByIdAsync(request.Id);

                if (user == null)
                {
                    throw new Exception($"user with ID {request.Id} not found.");
                }


                _mapper.Map(request, user, typeof(UpdateUserRequestCommand), typeof(ApplicationUser));

                if (await _uow.Complete()) return
                    Unit.Value;

                throw new Exception($"Updating user with ID {request.Id} failed on save.");


            }
        }

       
    }
}
