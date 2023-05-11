using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.AvatarRequest.Commands.UpdateAvatarRequest
{
    public class UpdateAvatarRequestHandlerCommand :
    IRequestHandler<
        UpdateAvatarRequestCommand,
        Unit
    >
    {
        private readonly IAvatarRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdateAvatarRequestHandlerCommand(IAvatarRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAvatarRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAvatarRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                throw new BadRequestException
                (
                    $"Command validation errors for type {typeof(UpdateAvatarRequestCommand).Name}",
                    validationResult.Errors
                );
            }

            var post = await _postRepository.GetByIdAsync(request.Id);

            if (post == null)
            {
                throw new Exception($"Avatar with ID {request.Id} not found.");
            }

            var postInputDto = _mapper.Map<AvatarDto>(request);
            _mapper.Map(postInputDto, post);

            await _postRepository.UpdateAsync(post);

            return Unit.Value;

        }
    }
}