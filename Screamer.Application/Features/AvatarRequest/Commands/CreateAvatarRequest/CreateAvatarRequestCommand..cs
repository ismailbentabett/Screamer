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

namespace Screamer.Application.Features.AvatarRequest.Commands.CreateAvatarRequest
{
    public class CreateAvatarRequestHandlerCommand : IRequestHandler
    <
        CreateAvatarRequestCommand,
        int
        >
    {
        private readonly IAvatarRepository _postRepository;
        private readonly IMapper _mapper;

        public CreateAvatarRequestHandlerCommand(IAvatarRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAvatarRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateAvatarRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                throw new BadRequestException
                (
                    $"Command validation errors for type {typeof(CreateAvatarRequestCommand).Name}",
                    validationResult.Errors
                );
            } 

            var post = _mapper.Map<Avatar>(request);

            post = await _postRepository.AddAsync(post);

            return post.Id;
        }
    }
}