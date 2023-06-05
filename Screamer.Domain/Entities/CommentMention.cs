using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class CommentMention : BaseEntity
    {
        public string PostTitle { get; set; }
        public string UserId { get; set; }
        public int? CommentId { get; set; }

        public ApplicationUser User { get; set; }
        public Comment Comment { get; set; }
    }
}
