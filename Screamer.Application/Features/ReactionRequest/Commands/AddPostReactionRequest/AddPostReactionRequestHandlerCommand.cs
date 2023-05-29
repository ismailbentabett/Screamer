using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest
{
    public class AddPostReactionRequestHandlerCommand
        : IRequestHandler<AddPostReactionRequestCommand, PostReactionDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddPostReactionRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<PostReactionDto> Handle(
            AddPostReactionRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);

            var post = await _uow.PostRepository.GetPostById((int)request.PostId);
            if (post == null)
                throw new NotFoundException(nameof(Post), (int)request.PostId);

            var reaction = new PostReaction
            {
                PostId = (int)request.PostId,
                UserId = request.UserId,
                ReactionType = request.ReactionType,
                CreatedAt = DateTime.Now,
                User = user,
                Post = post
            };

            _uow.ReactionRepository.AddPostReaction(reaction);

            if (await _uow.Complete())
            {
                return _mapper.Map<PostReactionDto>(reaction);
            }

            throw new BadRequestException("Problem adding Reaction");
        }
    }
}
