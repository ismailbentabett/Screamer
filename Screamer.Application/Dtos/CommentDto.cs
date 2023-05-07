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
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public string PostId { get; set; }
        public PostDto Post { get; set; }
        public string ParentId { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public string CommentableId { get; set; }
        public string CommentableType { get; set; }
        public ICollection<ReactionDto> Reactions { get; set; }


    }
}