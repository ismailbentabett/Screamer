using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain.Entities
{
    public class CommentHashtag : BaseEntity
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public int HashtagId { get; set; }
        public Hashtag Hashtag { get; set; }
    }
}
