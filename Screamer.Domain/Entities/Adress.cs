using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain.Entities
{
    public class Adress : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        
    }
}