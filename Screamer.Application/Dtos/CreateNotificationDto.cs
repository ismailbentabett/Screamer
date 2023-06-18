namespace Screamer.Application.Dtos
{
    public class CreateNotificationDto
    {        public string Message { get; set; }

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
    }
}
