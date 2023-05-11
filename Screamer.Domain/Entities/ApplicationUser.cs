using Microsoft.AspNetCore.Identity;
using Screamer.Domain;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Screamer.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }

/*         public string Cover { get; set; }
 */        public string Bio { get; set; }
        public string Website { get; set; }
        /*         public Adress Adress { get; set; }
         */
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

/*         public string Avatar { get; set; }
 */
/*         public ICollection<Avatar> Avatars { get; set; }
 */        /*   public Social Social { get; set; } */

        /*         public ICollection<Avatar> Avatars { get; set; }
         *//*         public ICollection<Post> Posts { get; set; }
         */        /* public ICollection<Follow> Followings { get; set; }
                public ICollection<Follow> Followers { get; set; } */
    }
}