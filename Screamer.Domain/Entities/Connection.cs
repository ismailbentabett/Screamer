namespace Screamer.Domain.Entities
{
    public class Connection
    {
        public Connection()
        {
            
        }
        public Connection(string connectionId, string userId)
        {
            ConnectionId = connectionId;
            UserId = userId;
        }

        public string ConnectionId { get; set; }
        public string UserId { get; set; }
    }
}