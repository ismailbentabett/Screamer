using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class CommentReaction : BaseEntity
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public string ReactionType { get; set; }

        [Required]
        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }

        public int CommentId { get; set; }
    }
}
