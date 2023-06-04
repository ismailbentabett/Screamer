using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Domain.Entities
{
    public class PostHashtagDto
    {
          public int HashtagId { get; set; }
        public HashtagDto Hashtag { get; set; }
    }
}