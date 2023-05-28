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

namespace Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest
{
    public class AddReactionRequestHandlerCommand : IRequestHandler<AddReactionRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddReactionRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            AddReactionRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var reaction = new Reaction();

            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            if (request.isPost == true)
            {
                var post = await _uow.PostRepository.GetPostById(request.PostId);
                if (post == null)
                    throw new NotFoundException(nameof(Post), request.PostId);

                reaction = new Reaction
                {
                    PostId = request.PostId,
                    UserId = request.UserId,
                    ReactionType = request.ReactionType,
                    CreatedAt = DateTime.Now,
                    User = user,
                    Post = post
                };
            }
            else
            {
                var comment = await _uow.CommentRepository.GetCommentById(request.CommentId);
                if (comment == null)
                    throw new NotFoundException(nameof(Comment), request.CommentId);

                reaction = new Reaction
                {
                    CommentId = request.CommentId,
                    UserId = request.UserId,
                    ReactionType = request.ReactionType,
                    CreatedAt = DateTime.Now,
                    User = user,
                    Comment = comment
                };
            }

            _uow.ReactionRepository.AddReaction(reaction);

            if (await _uow.Complete())
            {
                return reaction.Id;
            }

            throw new BadRequestException("Problem adding Reaction");
        }
    }
}
