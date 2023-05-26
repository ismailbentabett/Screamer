using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Helpers
{
    public class RecommendationParams : PaginationParams
    {
        public string UserId { get; set; }
        public string Predicate { get; set; } = "following";

        public string OrderBy { get; set; } = "CreatedAt";
    }
}
