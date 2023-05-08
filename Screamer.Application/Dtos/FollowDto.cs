using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class FollowDto
    {
                public int Id { get; set; }

    public int FollowerId { get; set; }
    public UserDto Follower { get; set; }
    public int FollowingId { get; set; }
    public UserDto Following { get; set; }
    }
}