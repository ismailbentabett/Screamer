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
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            if (request.isPost == true)
            {
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
                    return reaction.Id;
                }
            }
            else if (request.isPost == false)
            {
                var comment = await _uow.CommentRepository.GetCommentById((int)request.CommentId);
                if (comment == null)
                    throw new NotFoundException(nameof(Comment), (int)request.CommentId);

                var reaction = new CommentReaction
                {
                    CommentId = (int)request.CommentId,
                    UserId = request.UserId,
                    ReactionType = request.ReactionType,
                    CreatedAt = DateTime.Now,
                    User = user,
                    Comment = comment
                };

                _uow.ReactionRepository.AddCommentReaction(reaction);

                if (await _uow.Complete())
                {
                    return reaction.Id;
                }
            }

            throw new BadRequestException("Problem adding Reaction");
        }
    }
}
