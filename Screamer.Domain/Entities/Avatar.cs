using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Identity.Models;

namespace Screamer.Domain.Common
{
    public class Avatar : BaseEntity
    {
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}