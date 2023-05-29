using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class PostReactionDto
    {
        public string UserId { get; set; }

        public string ReactionType { get; set; }
        public int PostId { get; set; }
    }
}
