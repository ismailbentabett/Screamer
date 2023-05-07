using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain.Entities
{
    public class Role  : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}