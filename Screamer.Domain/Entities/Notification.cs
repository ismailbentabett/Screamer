using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Message { get; set; }

        public string Type { get; set; }

        public int ChatRoomId { get; set; }
        public int NotificationRoomId { get; set; }

        public int PostId { get; set; }

        public string senderId { get; set; }
        public string recieverId { get; set; }

        public int CommentId { get; set; }

        public int ReplyId { get; set; }

        public int ReactionId { get; set; }

        public int TagId { get; set; }

        public int MentionId { get; set; }

        public bool IsRead { get; set; }

    }
}
