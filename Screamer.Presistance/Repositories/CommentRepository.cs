using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Helpers;
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

        public async Task<Comment> AddComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
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

        public Task<PagedList<Comment>> GetPostComments(CommentParams commentParams)
        {
            var query = _context.Comments
                .Where(c => c.Post.Id == commentParams.postId && c.ParentComment == null)
                .AsQueryable();

            query = commentParams.OrderBy switch
            {
                "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
                _ => query.OrderByDescending(u => u.CreatedAt)
            };

            return PagedList<Comment>.CreateAsync(
                query,
                commentParams.PageNumber,
                commentParams.PageSize
            );
        }

        public Task<PagedList<Comment>> GetRepliesByCommentId(CommentParams commentParams)
        {
            var query = _context.Comments
                .Where(
                    c => c.ParentComment.Id == commentParams.commentId && c.ParentComment != null
                )
                .AsQueryable();

            query = commentParams.OrderBy switch
            {
                "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
                _ => query.OrderByDescending(u => u.CreatedAt)
            };

            return PagedList<Comment>.CreateAsync(
                query,
                commentParams.PageNumber,
                commentParams.PageSize
            );
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

        List<Comment> ICommentRepository.GetRepliesByCommentId(int commentId)
        {
            throw new NotImplementedException();
        }
    }
}
