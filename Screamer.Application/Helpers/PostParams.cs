using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Helpers
{
    public class PostParams: PaginationParams
    {
              public int Id { get; set; }

        public string UserId { get; set; }

                public string OrderBy { get; set; } = "CreatedAt";


        /*     public ICollection<Comment> Comments { get; set; }
            public ICollection<Reaction> Reactions { get; set; }  */
    }
}