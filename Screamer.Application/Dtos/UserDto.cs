using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<RoleDto> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cover { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public AdressDto Adress { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public SocialDto Social { get; set; }

        public ICollection<AvatarDto> Avatars { get; set; }
        public ICollection<PostDto> Posts { get; set; }
        public ICollection<FollowDto> Followers { get; set; }
        public ICollection<FollowDto> Followings { get; set; }

    }
}