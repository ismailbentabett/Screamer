using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class PostCategoryDto
    {
        
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
    }
}
