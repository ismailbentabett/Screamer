using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class ChatRoom : BaseEntity
    {
        public ICollection<ChatRoomUser> ChatRoomUsers { get; set; } = new List<ChatRoomUser>();

        [ForeignKey("LatestMessageId")]
        public Message LatestMessage { get; set; }
        public int LatestMessageId { get; set; }
    }
}
