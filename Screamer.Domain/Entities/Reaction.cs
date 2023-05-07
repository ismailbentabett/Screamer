using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain.Entities
{
    public class Reaction : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public string PostId { get; set; }
        public Post Post { get; set; }
        public string CommentId { get; set; }
        public Comment Comment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}