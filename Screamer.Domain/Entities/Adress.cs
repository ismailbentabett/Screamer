using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int UserId { get; set; }
        
     
        
    }
}