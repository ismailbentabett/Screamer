using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.StoryImageRequest
{
    public class SetMainPostImageRequestHandlerCommand
        : IRequestHandler<SetMainStoryImageRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SetMainPostImageRequestHandlerCommand(
            IMapper mapper,
            IUnitOfWork uow
        )
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            SetMainStoryImageRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var story = await _uow.StoryRepository.GetByIdAsync(request.storyId);

            if (story == null)
                throw new NotFoundException(nameof(Story), request.storyId);

            var storyImage = story.StoryImages.FirstOrDefault(x => x.Id == request.storyImageId);

            if (storyImage == null)
                throw new NotFoundException(nameof(PostImage), request.storyId);

            if (storyImage.IsMain)
                throw new BadRequestException("this is already your main photo");

            var currentMain = story.StoryImages.FirstOrDefault(x => x.IsMain);
            if (currentMain != null)
                currentMain.IsMain = false;
            storyImage.IsMain = true;
            if (await _uow.Complete())
            {
                return storyImage.Id;
            }
            else
            {
                throw new Exception("problem saving changes");
            }
        }
    }
}
