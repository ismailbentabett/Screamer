using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class Social : BaseEntity
    {
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Instagram { get; set; }
        public string Youtube { get; set; }
        public string Twitch { get; set; }
        public string Tiktok { get; set; }
        public string Snapchat { get; set; }
        public string Pinterest { get; set; }
        public string Reddit { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Website { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}