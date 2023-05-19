using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain;
using Screamer.Domain.Entities;

namespace Screamer.Application.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }


        /*         public string Cover { get; set; }
         */
        public string Bio { get; set; }
        public string Website { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string userName { get; set; }
        public string AvatarUrl { get; set; }

        public List<AvatarDto> Avatars { get; set; } = new();
        public List<PostDto> Posts { get; set; } = new();


        public List<Message> MessagesSent { get; set; }
        public List<Message> MessagesReceived { get; set; }

        public List<Follow> Followers { get; set; } = new();
        public List<Follow> Following { get; set; } = new();


 public List<CoverDto> Covers { get; set; } = new();
        public string CoverUrl { get; set; }

        /*         public string Avatar { get; set; }
         */


    }
}