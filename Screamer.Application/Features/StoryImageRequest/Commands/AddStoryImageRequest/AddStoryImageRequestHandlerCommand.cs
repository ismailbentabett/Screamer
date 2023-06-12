using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Screamer.Domain.Entities;
using Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest;

namespace Screamer.Application.Features.StoryImageRequest
{
    public class AddStoryImageRequestHandlerCommand : IRequestHandler<AddStoryImageRequestCommand, int>
    {
        private readonly IStoryImageRepository _storyImageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddStoryImageRequestHandlerCommand(
            IStoryImageRepository storyImageRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IUserRepository userRepository
        )
        {
            _storyImageRepository = storyImageRepository;
            _mapper = mapper;
            _uow = uow;
            _userRepository = userRepository;
        }

        public async Task<int> Handle(
            AddStoryImageRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var story = await _uow.StoryRepository.GetStoryByIdAsync(request.storyId);

            if (story == null)
                throw new NotFoundException(nameof(Story), request.storyId);

            var result = await _storyImageRepository.AddPhotoAsync(request.file);

            if (result.Error != null)
                throw new BadRequestException(result.Error.Message);

            var storyImage = new StoryImage
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (story.StoryImages.Count == 0)
                storyImage.IsMain = true;

            story.StoryImages.Add(storyImage);

            if (await _uow.Complete())
            {
                return story.Id;
            }

            throw new BadRequestException("Problem adding photo");
        }
    }
}
