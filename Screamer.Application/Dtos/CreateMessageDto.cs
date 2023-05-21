namespace Screamer.Application.Dtos
{
    public class CreateMessageDto
    {
        public string RecipientId { get; set; }
        public string userId { get; set; }
        public string Content { get; set; }
    }
}