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

namespace Screamer.Application.Features.CommentRequest.Commands.AddReplyRequest
{
    public class AddReplyRequestHandlerCommand : IRequestHandler<AddReplyRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddReplyRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            AddReplyRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            var post = await _uow.PostRepository.GetPostById(request.PostId);
            if (post == null)
                throw new NotFoundException(nameof(Post), request.PostId);

            var parentComment = await _uow.CommentRepository.GetCommentById(
                request.ParentCommentId
            );
            if (parentComment == null)
                throw new NotFoundException(nameof(Comment), request.ParentCommentId);

            Comment comment = new Comment
            {
                PostId = request.PostId,
                UserId = request.UserId,
                Content = request.Content,
                CreatedAt = DateTime.Now,
                ParentCommentId = request.ParentCommentId,
                ParentComment = parentComment,
                User = user,
                Post = post
            };

            foreach (var hashTagName in request.Hashtags)
            {
                var hashtag = await _uow.HashtagRepository.GetHashTagByNameAsync(hashTagName);
                if (hashtag == null)
                {
                    hashtag = new Hashtag { Name = hashTagName };
                }
                var commentHashtag = new CommentHashtag { Hashtag = hashtag, Comment = comment };
                comment.CommentHashtags.Add(commentHashtag);
                hashtag.CommentHashtags.Add(commentHashtag);
            }

            if (request.MentionsArr != null)
            {
                foreach (var mention in request.MentionsArr)
                {
                    var userMention = await _uow.UserRepository.GetUserByUsernameAsync(mention);

                    if (userMention == null)
                    {
                        throw new Exception($"User '{mention}' does not exist.");
                    }
                    var commentMention = new CommentMention
                    {
                        User = userMention,
                        Comment = comment,
                    };
                    comment.Mentions.Add(commentMention);
                    userMention.CommentMentions.Add(commentMention);
                }
            }

            await _uow.CommentRepository.AddComment(comment);

            await _uow.Complete();

            return comment.Id;
        }
    }
}
