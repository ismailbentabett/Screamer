using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Dtos
{
    public class PostSearchDto
    {
        [JsonPropertyAttribute("objectID")]
        public int objectID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }

        /*     public ICollection<Comment> Comments { get; set; }
            public ICollection<Reaction> Reactions { get; set; }  */
        public int Views { get; set; }

        public string PostImageUrl { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();

        public ICollection<PostImageDto> PostImages { get; set; } = new List<PostImageDto>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
