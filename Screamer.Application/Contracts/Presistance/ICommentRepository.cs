using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Contracts.Presistance
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Comment GetCommentById(int commentId);
        void AddComment(Comment comment);
        void RemoveComment(Comment comment);
        List<Comment> GetCommentsByPost(Post post);
        List<Comment> GetCommentsByUser(ApplicationUser user);
        void AddReply(Comment parentComment, Comment reply);
        void RemoveReply(Comment parentComment, Comment reply);
        List<Comment> GetRepliesByComment(Comment comment);
    }
}