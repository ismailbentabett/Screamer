using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class Cover
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}