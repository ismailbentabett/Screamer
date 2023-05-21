using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class ChatRoomDto
    {
        public string Id;
        public ICollection<ChatRoomUserDto> ChatRoomUsers { get; set; }

        public MessageDto LatestMessage { get; set; }
    }

    public class ChatRoomUserDto
    {
        public int ChatroomId { get; set; }
        public ChatRoomDto ChatRoom { get; set; }

        public string UserId { get; set; }
        public UserDto User { get; set; }
    }
}
