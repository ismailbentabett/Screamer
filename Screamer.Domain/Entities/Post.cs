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

        public string ObjectID { get; set; }

        public int MoodId { get; set; }
        public Mood Mood { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        public ICollection<PostCategory> PostCategories { get; set; } = new List<PostCategory>();

        public ICollection<PostHashtag> PostHashtags { get; set; } = new List<PostHashtag>();
        public ICollection<PostMention> Mentions { get; set; } = new List<PostMention>();
        public ICollection<BookMark> BookMarks { get; set; } = new List<BookMark>();
    }
}
