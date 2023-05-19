using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Entities;

namespace Screamer.Application.Dtos
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string userName { get; set; }

        public string Bio { get; set; }
        public string Website { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public Social Socials { get; set; }
        public Adress Adress { get; set; }









    }
}