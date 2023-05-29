using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IReactionRepository
    {
        PostReaction GetPostReactionById(int reactionId);

        CommentReaction GetCommentReactionById(int reactionId);
        void AddPostReaction(PostReaction reaction);
        void AddCommentReaction(CommentReaction reaction);
        void RemovePostReaction(PostReaction reaction);
        void RemoveCommentReaction(CommentReaction reaction);

        //update
        void UpdatePostReaction(PostReaction reaction);
        void UpdateCommentReaction(CommentReaction reaction);

       Task< CommentReaction> GetCommentReactionByCommentAndUser(int commentId, string userId);
        Task< PostReaction> GetPostReactionByPostAndUser(int postId, string userId);
    }
}
