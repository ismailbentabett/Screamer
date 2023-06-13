using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Identity.Models;

namespace Screamer.Application.Dtos
{
    public class BookMarkDto
    {
        public string UserId { get; set; }

        public UserDto User { get; set; }

        public int PostId { get; set; }

        public PostDto Post { get; set; }
    }
}
