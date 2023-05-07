using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Domain.Common
{
    public class Avatar : BaseEntity
    {
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}