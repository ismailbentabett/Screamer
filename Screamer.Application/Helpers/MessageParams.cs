using Screamer.Application.Helpers;

namespace   Screamer.Presistance
{
    public class MessageParams : PaginationParams
    {
        public string Username { get; set; }
        public string Container { get; set; } = "Unread";
    }
}