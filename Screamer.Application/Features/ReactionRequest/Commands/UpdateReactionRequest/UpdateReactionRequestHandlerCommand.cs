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

namespace Screamer.Application.Features.ReactionRequest.Commands.UpdateReactionRequest
{
    public class UpdateReactionRequestHandlerCommand
        : IRequestHandler<UpdateReactionRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UpdateReactionRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Unit> Handle(
            UpdateReactionRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var reaction = _uow.ReactionRepository.GetReactionById(request.ReactionId);

            if (reaction == null)
                throw new NotFoundException(nameof(Reaction), request.ReactionId);

            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);

            if (request.isPost == true)
            {
                var post = await _uow.PostRepository.GetPostById(request.PostId);
                if (post == null)
                    throw new NotFoundException(nameof(Post), request.PostId);

                reaction.PostId = request.PostId;
                reaction.UserId = request.UserId;
                reaction.ReactionType = request.ReactionType;
                reaction.UpdatedAt = DateTime.Now;
                reaction.User = user;
                reaction.Post = post;
            }
            else
            {
                var comment = await _uow.CommentRepository.GetCommentById(request.CommentId);
                if (comment == null)
                    throw new NotFoundException(nameof(Comment), request.CommentId);

                reaction.CommentId = request.CommentId;
                reaction.UserId = request.UserId;
                reaction.ReactionType = request.ReactionType;
                reaction.UpdatedAt = DateTime.Now;
                reaction.User = user;
                reaction.Comment = comment;
            }

            await _uow.ReactionRepository.UpdateAsync(reaction);
            if (await _uow.Complete())
            {
                return Unit.Value;
            }

            throw new BadRequestException("Problem adding Reaction");
        }
    }
}
