using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string PostId { get; set; }
        public Post Post { get; set; }
        public string ParentId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string CommentableId { get; set; }
        public string CommentableType { get; set; }
        public ICollection<Reaction> Reactions { get; set; }


    }
}