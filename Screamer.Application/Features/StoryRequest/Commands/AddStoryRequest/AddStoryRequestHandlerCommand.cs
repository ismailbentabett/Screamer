using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.StoryRequest.Commands.AddStoryRequest
{
    public class AddStoryRequestHandlerCommand : IRequestHandler<AddStoryRequestCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public AddStoryRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            AddStoryRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);

            var story = _mapper.Map<AddStoryRequestCommand, Story>(request);

            story.User = user;

            await _uow.StoryRepository.AddAsync(story);

            await _uow.Complete();

                return story.Id;
        }
    }
}
