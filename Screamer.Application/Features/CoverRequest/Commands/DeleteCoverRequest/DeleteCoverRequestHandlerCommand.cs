using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Features.AvatarRequest.Commands.DeleteAvatarRequest;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.CoverRequest.Commands.DeleteCoverRequest
{
    public class DeleteCoverRequestHandlerCommand :
    IRequestHandler
    <
        DeleteCoverRequestCommand,
        Unit
        >
    {
        private readonly ICoverRepository _coverRepository;
        private readonly IUnitOfWork _uow;



        public DeleteCoverRequestHandlerCommand( IUnitOfWork uow , ICoverRepository coverRepository
           
        )
        {
            _coverRepository = coverRepository;
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteCoverRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(
                      request.userId
                  );

            if (user == null) throw new NotFoundException(
                nameof(ApplicationUser), request.userId
      );

            var avatar = user.Covers.FirstOrDefault(x => x.Id == request.coverId);

            if (avatar == null) throw new NotFoundException(
                nameof(Cover), request.userId
            );

            if (avatar.IsMain) throw new
                BadRequestException("You cannot delete your main photo");

            if (avatar.PublicId != null)
            {
                var result = await _coverRepository.DeletePhotoAsync(avatar.PublicId);
                if (result.Error != null)
                    throw new Exception(result.Error.Message);
            }

            user.Covers.Remove(avatar);

            if (await _uow.Complete())
            {
                return Unit.Value;
            }
            else
            {
                throw new Exception("Problem deleting photo");
            }
        }
    }
}