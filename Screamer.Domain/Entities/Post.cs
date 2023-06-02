using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Domain.Common
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
        public List<PostReaction> Reactions { get; set; } = new();
        public List<Comment> Comments { get; set; } = new();
        public int Views { get; set; }
        public List<PostImage> PostImages { get; set; } = new();
        public string PostImageUrl { get; set; }

        public Post()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public string objectID => Id.ToString();

        [JsonPropertyName("objectID")]
        public string ObjectID { get; set; }

        [ForeignKey(nameof(MoodId))]
        public Mood Mood { get; set; }
        public int MoodId { get; set; }
        public ICollection<PostUserMention> PostUserMentions { get; set; } = new List<PostUserMention>();
        public ICollection<PostUserTag> PostUserTags { get; set; } = new List<PostUserTag>();
        public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();

        public ICollection<PostHashtag> PostHashtags { get; set; } = new List<PostHashtag>();
    }
}
