using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain.Entities
{
    public class Hashtag : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<PostHashtag> PostHashtags { get; set; } = new List<PostHashtag>();
        public ICollection<CommentHashtag> CommentHashtags { get; set; } =
            new List<CommentHashtag>();
    }
}
