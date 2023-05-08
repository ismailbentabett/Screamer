using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Entities;

namespace Screamer.Domain.Common
{
    public class User : BaseEntity
    {
            public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<Role> Roles { get; set; }
        public string FirstName { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Lastname { get; set; }
        public string Cover { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public Adress Adress { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public Social Social { get; set; }

        public ICollection<Avatar> Avatars { get; set; }
/*         public ICollection<Post> Posts { get; set; }
 */        public ICollection<Follow> Followings { get; set; }
        public ICollection<Follow> Followers { get; set; }

    }
}