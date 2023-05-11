using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Password { get; set; }

/*         public string Cover { get; set; }
 */        public string Bio { get; set; }
        public string Website { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

/*         public string Avatar { get; set; }
 */


    }
}