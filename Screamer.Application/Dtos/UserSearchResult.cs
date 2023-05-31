using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class UserSearchResult
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string userName { get; set; }
        public string AvatarUrl { get; set; }
        public string CoverUrl { get; set; }
        public SocialDto Socials { get; set; }
        public AdressDto Adress { get; set; }

        [JsonPropertyName("objectID")]
        public string ObjectID { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        public List<AvatarDto> Avatars { get; set; } = new();
        public List<CoverDto> Covers { get; set; } = new();
    }
}
