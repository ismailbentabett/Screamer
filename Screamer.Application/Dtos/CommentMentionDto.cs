using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class CommentMentionDto
    {
        public CommentDto Comment { get; set; }
        public int CommentId { get; set; }
    }
}
