using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.AvatarRequest.Commands.DeleteAvatarRequest
{
    public class DeleteAvatarRequestHandlerCommand :
    IRequestHandler
    <
        DeleteAvatarRequestCommand,
        Unit
        >
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUnitOfWork _uow;



        public DeleteAvatarRequestHandlerCommand(IAvatarRepository avatarRepository , 
            IUnitOfWork uow
        )
        {
            _avatarRepository = avatarRepository;
            _uow = uow;
        }

    public async Task<Unit> Handle(DeleteAvatarRequestCommand request, CancellationToken cancellationToken)
        {
      var user = await _uow.UserRepository.GetUserByIdAsync(
                request.userId
            );

            if (user == null) throw new NotFoundException(
                nameof(ApplicationUser), request.userId
      );

            var avatar = user.Avatars.FirstOrDefault(x => x.Id == request.avatarId);

            if (avatar == null)  throw new NotFoundException(
                nameof(Avatar), request.userId
            );

            if (avatar.IsMain) throw new 
                BadRequestException("You cannot delete your main photo");

            if (avatar.PublicId != null)
            {
                var result = await _avatarRepository.DeletePhotoAsync(avatar.PublicId);
                if (result.Error != null) 
                    throw new Exception(result.Error.Message);
            }

            user.Avatars.Remove(avatar);

            if (await _uow.Complete()) {
                return Unit.Value;
            } else {
                throw new Exception("Problem deleting photo");
            }
        }
    }
}