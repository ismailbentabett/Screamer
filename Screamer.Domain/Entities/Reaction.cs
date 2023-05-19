using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class Reaction : BaseEntity
    {
        public string UserId { get; set; }
        [ForeignKey(
            nameof(UserId)
        )]
        public ApplicationUser User { get; set; }
        public int PostId { get; set; }
        [ForeignKey(
            nameof(PostId)
        )]
        public Post Post { get; set; }

        [ForeignKey(
                  nameof(CommentId)
              )]
        public Comment Comment { get; set; }

        public int CommentId { get; set; }

        public string ReactionType { get; set; }
    }
}