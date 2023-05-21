using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class ChatRoomUser : BaseEntity
    {
           public int ChatroomId { get; set; }
    public ChatRoom ChatRoom { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    }
}