using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class AvatarDto
    {
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}