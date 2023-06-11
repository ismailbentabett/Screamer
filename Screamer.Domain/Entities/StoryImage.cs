using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Domain.Entities
{
    public class StoryImage
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }

        public int StoryId { get; set; }

        [ForeignKey("StoryId")]
        public Story Story { get; set; }
    }
}
