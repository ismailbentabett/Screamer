using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class Adress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }





    }
}