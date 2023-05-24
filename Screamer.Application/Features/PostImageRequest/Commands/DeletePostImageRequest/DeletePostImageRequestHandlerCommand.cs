using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.postImageRequest.Commands
{
    public class DeletePostImageRequestHandlerCommand
        : IRequestHandler<DeletePostImageRequestCommand, Unit>
    {
        private readonly IPostImageRepository _PostImageRepository;
        private readonly IUnitOfWork _uow;

        public DeletePostImageRequestHandlerCommand(
            IPostImageRepository PostImageRepository,
            IUnitOfWork uow
        )
        {
            _PostImageRepository = PostImageRepository;
            _uow = uow;
        }

        public async Task<Unit> Handle(
            DeletePostImageRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var post = await _uow.PostRepository.GetByIdAsync(request.postId);

            if (post == null)
                throw new NotFoundException(nameof(Post), request.postId);

            var postImage = post.PostImages.FirstOrDefault(x => x.Id == request.postImageId);

            if (postImage == null)
                throw new NotFoundException(nameof(PostImage), request.postId);

            if (postImage.IsMain)
                throw new BadRequestException("You cannot delete your main photo");

            if (postImage.PublicId != null)
            {
                var result = await _PostImageRepository.DeletePhotoAsync(postImage.PublicId);
                if (result.Error != null)
                    throw new Exception(result.Error.Message);
            }

            post.PostImages.Remove(postImage);

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
