using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Commands.CreatePostRequest
{
    public class CreatePostRequestHandlerCommand : IRequestHandler
    <
        CreatePostRequestCommand,
        int
        >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public CreatePostRequestHandlerCommand(IPostRepository postRepository, IMapper mapper,
            IUnitOfWork uow
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(CreatePostRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePostRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                throw new BadRequestException
                (
                    $"Command validation errors for type {typeof(CreatePostRequestCommand).Name}",
                    validationResult.Errors
                );
            }

            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);

            if (user == null) throw new NotFoundException(
                nameof(ApplicationUser), request.UserId);
            var post = _mapper.Map<CreatePostRequestCommand, Post>(request);
            post.User = user;
            await _postRepository.AddAsync(post);
            await _uow.Complete();
            return post.Id;

        }
    }
}