using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public string PostId { get; set; }
        public PostDto Post { get; set; }
        public string ParentId { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public string CommentableId { get; set; }
        public string CommentableType { get; set; }
        public ICollection<ReactionDto> Reactions { get; set; }

        public ICollection<UserMentionDto> Mentions { get; set; } = new List<UserMentionDto>();

        public int? ParentCommentId { get; set; }
        public CommentDto ParentComment { get; set; } 
        public List<CommentDto> Replies { get; set; }
    }
}
