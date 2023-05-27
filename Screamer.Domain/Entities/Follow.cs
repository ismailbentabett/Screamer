using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain
{
    public class Follow : BaseEntity
    {
        [
            ForeignKey("SourceUserId")
        
        ]
       public ApplicationUser SourceUser { get; set; }
        public string SourceUserId { get; set; }
        [
            ForeignKey("TargetUserId")
        ]
        public ApplicationUser TargetUser { get; set; }
        public string TargetUserId { get; set; }
       
    }
}