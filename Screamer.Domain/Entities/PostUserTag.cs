using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class PostUserTag: BaseEntity
    {
          public int PostId { get; set; }

        public Post Post { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}