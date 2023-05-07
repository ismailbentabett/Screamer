using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest
{
    public class UpdatePostRequestHandlerCommand :
    IRequestHandler<
        UpdatePostRequestCommand,
        Unit
    >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostRequestHandlerCommand(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePostRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePostRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                throw new BadRequestException
                (
                    $"Command validation errors for type {typeof(UpdatePostRequestCommand).Name}",
                    validationResult.Errors
                );
            }

            var post = await _postRepository.GetByIdAsync(request.Id);

            if (post == null)
            {
                throw new Exception($"Post with ID {request.Id} not found.");
            }

            var postInputDto = _mapper.Map<PostInputDto>(request);
            _mapper.Map(postInputDto, post);

            await _postRepository.UpdateAsync(post);

            return Unit.Value;

        }
    }
}