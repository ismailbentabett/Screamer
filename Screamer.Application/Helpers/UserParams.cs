namespace Screamer.Application.Helpers
{
    public class UserParams : PaginationParams
    {



        public string Bio { get; set; }
        public string Website { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string userName { get; set; }
        public string AvatarUrl { get; set; }
        //OrderBy
        public string OrderBy { get; set; } = "CreatedAt";

        public DateTime CreatedAt { get; set; }


    }
}