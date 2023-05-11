using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;

namespace Screamer.Application.Features.AvatarRequest.Commands.DeleteAvatarRequest
{
    public class DeleteAvatarRequestHandlerCommand :
    IRequestHandler
    <
        DeleteAvatarRequestCommand,
        Unit
        >
    {
        private readonly IAvatarRepository _postRepository;

        public DeleteAvatarRequestHandlerCommand(IAvatarRepository postRepository)
        {
            _postRepository = postRepository;
        }

    public async Task<Unit> Handle(DeleteAvatarRequestCommand request, CancellationToken cancellationToken)
        {
          
      var AvatarToDelete = await _postRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (AvatarToDelete == null)
            {
                throw new NotFoundException(nameof(Avatar), request.Id);
            }

            // remove from database
            await _postRepository.DeleteAsync(AvatarToDelete);

            // retun record id
            return Unit.Value;
    }
}
}