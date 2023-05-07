using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class ReactionDto
    {
                        public int Id { get; set; }

        public string Name { get; set; }
        public string Color { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public string PostId { get; set; }
        public PostDto Post { get; set; }
        public string CommentId { get; set; }
        public CommentDto Comment { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}