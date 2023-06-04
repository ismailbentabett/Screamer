using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }

        /*     public ICollection<Comment> Comments { get; set; }
            public ICollection<Reaction> Reactions { get; set; }  */
        public int Views { get; set; }

        public string PostImageUrl { get; set; }
        public ICollection<PostCategoryDto> PostCategories { get; set; } =
            new List<PostCategoryDto>();
        public ICollection<PostHashtagDto> PostHashtags { get; set; } = new List<PostHashtagDto>();
        public ICollection<PostImageDto> PostImages { get; set; } = new List<PostImageDto>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public MoodDto Mood { get; set; }

        public ICollection<UserTagDto> UserTags { get; set; } = new List<UserTagDto>();
        public ICollection<UserMentionDto> UserMentions { get; set; } = new List<UserMentionDto>();
    }
}
