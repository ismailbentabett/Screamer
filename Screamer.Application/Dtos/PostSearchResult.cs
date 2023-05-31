using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class PostSearchResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }

        public int Views { get; set; }

        public string PostImageUrl { get; set; }


        [JsonPropertyName("objectID")]
        public string ObjectID { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }

        public ICollection<PostImageDto> PostImages { get; set; } = new List<PostImageDto>();
    }
}
