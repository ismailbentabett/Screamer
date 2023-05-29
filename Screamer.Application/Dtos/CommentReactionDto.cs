using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class CommentReactionDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string ReactionType { get; set; }
        public int CommentId { get; set; }
    }
}
