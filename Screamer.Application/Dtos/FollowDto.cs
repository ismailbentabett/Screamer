using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class FollowDto
    {
        public string FollowingId { get; set; }
        public UserDto Follower { get; set; }
        public string FollowerId { get; set; }
        public UserDto Following { get; set; }
    }
}