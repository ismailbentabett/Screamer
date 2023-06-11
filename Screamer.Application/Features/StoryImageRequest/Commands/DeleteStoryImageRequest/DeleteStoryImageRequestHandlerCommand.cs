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

namespace Screamer.Application.Features.StoryImageRequest
{
    public class DeleteStoryImageRequestHandlerCommand :
    IRequestHandler
    <
        DeleteStoryImageRequestCommand,
        Unit
        >
    {
        private readonly IStoryImageRepository _storyImageRepository;
        private readonly IUnitOfWork _uow;



        public DeleteStoryImageRequestHandlerCommand(IStoryImageRepository storyImageRepository , 
            IUnitOfWork uow
        )
        {
            _storyImageRepository = storyImageRepository;
            _uow = uow;
        }

    public async Task<Unit> Handle(DeleteStoryImageRequestCommand request, CancellationToken cancellationToken)
        {
      var story = await _uow.StoryRepository.GetByIdAsync(
                request.storyId
            );

            if (story == null) throw new NotFoundException(
                nameof(Story), request.storyId
      );

            var storyImage = story.StoryImages.FirstOrDefault(x => x.Id == request.storyImageId);

            if (storyImage == null)  throw new NotFoundException(
                nameof(StoryImage), request.storyImageId
            );

            if (storyImage.IsMain) throw new 
                BadRequestException("You cannot delete your main photo");

            if (storyImage.PublicId != null)
            {
                var result = await _storyImageRepository.DeletePhotoAsync(storyImage.PublicId);
                if (result.Error != null) 
                    throw new Exception(result.Error.Message);
            }

            story.StoryImages.Remove(storyImage);

            if (await _uow.Complete()) {
                return Unit.Value;
            } else {
                throw new Exception("Problem deleting photo");
            }
        }

       
    }
}