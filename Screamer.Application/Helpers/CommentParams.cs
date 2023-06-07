using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Helpers
{
    public class CommentParams : PaginationParams
    {
        public int commentId { get; set; }


        public int postId { get; set; }

        public int parentCommentId { get; set; }

        public string OrderBy { get; set; } = "CreatedAt";
    }
}
