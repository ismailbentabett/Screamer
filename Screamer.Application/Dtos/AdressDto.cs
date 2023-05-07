using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class AdressDto
    {
                public int Id { get; set; }

        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        
    }
}