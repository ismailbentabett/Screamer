using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class Comment : BaseEntity
    {

        [
        ForeignKey(
            nameof(UserId)
        )
        ]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        [
            ForeignKey(
                nameof(PostId)
            )
        ]
        public Post Post { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public List<Comment> Replies { get; set; }
        public List<Reaction> Reactions { get; set; }


    }
}