using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.NotificationRequest.Commands.CreateNotificationRequest
{
    public class CreateNotificationRequestCommand : IRequest<int>
    {
        public string Message { get; set; }

        public string Type { get; set; }

        public int ChatRoomId { get; set; }
        public string NotificationRoomId { get; set; }

        public int PostId { get; set; }

        public string SenderId { get; set; }
        public string RecieverId { get; set; }

        public int CommentId { get; set; }

        public int ReplyId { get; set; }

        public int ReactionId { get; set; }

        public int TagId { get; set; }

        public int MentionId { get; set; }

        public bool IsRead { get; set; }
        public UserDto user { get; set; }
    }
}
