using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Helpers
{
    public class NotificationParams : PaginationParams
    {
        public string SenderId { get; set; }

        public string OrderBy { get; set; } = "CreatedAt";
    }
}
