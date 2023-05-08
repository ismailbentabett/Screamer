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

        public CreatePostRequestHandlerCommand(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
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

            var postInputDto = _mapper.Map<Post>(request);
            var post = _mapper.Map<Post>(postInputDto);

            await _postRepository.AddAsync(post);

            return post.Id;
        }
    }
}