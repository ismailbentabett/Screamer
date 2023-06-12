using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.StoryRequest.Commands.DeleteStoryRequest
{
    public class DeleteStoryRequestHandlerCommand : IRequestHandler<DeleteStoryRequestCommand, Unit>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;
        private readonly IStoryImageRepository _storyImageRepository;

        public DeleteStoryRequestHandlerCommand(
            IMapper mapper,
            IUnitOfWork uow,
            IStoryImageRepository storyImageRepository
        )
        {
            _mapper = mapper;
            _uow = uow;
            _storyImageRepository = storyImageRepository;
        }

        public async Task<Unit> Handle(
            DeleteStoryRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var story = await _uow.StoryRepository.GetByIdAsync(request.storyId);

            if (story == null)
                throw new NotFoundException(nameof(Story), request.storyId);

            var storyImage = story.StoryImages.FirstOrDefault(x => x.Id == request.storyId);

            if (storyImage == null)
                throw new NotFoundException(nameof(StoryImage), request.storyId);

            if (storyImage.IsMain)
                throw new BadRequestException("You cannot delete your main photo");

            if (storyImage.PublicId != null)
            {
                var result = await _storyImageRepository.DeletePhotoAsync(storyImage.PublicId);
                if (result.Error != null)
                    throw new Exception(result.Error.Message);
            }

            story.StoryImages.Remove(storyImage);

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
