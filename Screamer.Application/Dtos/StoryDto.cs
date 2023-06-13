using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class StoryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserDto User { get; set; }

        public int Views { get; set; }
        public List<StoryImageDto> StoryImages { get; set; } = new();
        public string StoryImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
