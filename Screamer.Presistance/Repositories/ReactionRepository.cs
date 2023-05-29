using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class ReactionRepository : IReactionRepository
    {
        protected readonly ScreamerDbContext _context;

        public ReactionRepository(ScreamerDbContext context)
        {
            _context = context;
        }

        public void AddPostReaction(PostReaction reaction)
        {
            _context.PostReactions.Add(reaction);
        }

        public void AddCommentReaction(CommentReaction reaction)
        {
            _context.CommentReactions.Add(reaction);
        }

        public PostReaction GetPostReactionById(int reactionId)
        {
            return _context.PostReactions.FirstOrDefault(r => r.Id == reactionId);
        }

        public CommentReaction GetCommentReactionById(int reactionId)
        {
            return _context.CommentReactions.FirstOrDefault(r => r.Id == reactionId);
        }

        public void RemovePostReaction(PostReaction reaction)
        {
            _context.PostReactions.Remove(reaction);
        }

        public void RemoveCommentReaction(CommentReaction reaction)
        {
            _context.CommentReactions.Remove(reaction);
        }

        PostReaction IReactionRepository.GetPostReactionById(int reactionId)
        {
            var postReaction = _context.PostReactions.FirstOrDefault(r => r.Id == reactionId);
            return postReaction;
        }

        CommentReaction IReactionRepository.GetCommentReactionById(int reactionId)
        {
            var commentReaction = _context.CommentReactions.FirstOrDefault(r => r.Id == reactionId);
            return commentReaction;
        }

        public void UpdatePostReaction(PostReaction reaction)
        {
            _context.PostReactions.Update(reaction);
        }

        public void UpdateCommentReaction(CommentReaction reaction)
        {
            _context.CommentReactions.Update(reaction);
        }

        public Task<PostReaction> GetPostReactionByPostAndUser(int postId, string userId)
        {
            var postReaction = _context.PostReactions.FirstOrDefault(
                r => r.PostId == postId && r.UserId == userId
            );

            return Task.FromResult(postReaction);
        }

        public Task<CommentReaction> GetCommentReactionByCommentAndUser(
            int commentId,
            string userId
        )
        {
            var commentReaction = _context.CommentReactions.FirstOrDefault(
                r => r.CommentId == commentId && r.UserId == userId
            );
            return Task.FromResult(commentReaction);
        }
    }
}
