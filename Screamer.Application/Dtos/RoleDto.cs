using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class RoleDto
    {
                        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}