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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(ScreamerDbContext context)
            : base(context) { }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void AddReply(Comment parentComment, Comment reply)
        {
            parentComment.Replies.Add(reply);
            _context.SaveChanges();
        }

        public async Task<Comment> GetCommentById(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            return comment;
        }

        public List<Comment> GetCommentsByPost(Post post)
        {
            return _context.Comments.Where(c => c.Post.Id == post.Id).ToList();
        }

        public List<Comment> GetCommentsByUser(ApplicationUser user)
        {
            return _context.Comments.Where(c => c.User.Id == user.Id).ToList();
        }

        public List<Comment> GetRepliesByComment(Comment comment)
        {
            return _context.Comments.Where(c => c.ParentComment == comment).ToList();
        }

        public void RemoveComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public void RemoveReply(Comment parentComment, Comment reply)
        {
            parentComment.Replies.Remove(reply);
            _context.SaveChanges();
        }
    }
}
