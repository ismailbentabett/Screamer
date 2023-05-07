using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<ReactionDto> Reactions { get; set; }
        public int Views { get; set; }

    }
}