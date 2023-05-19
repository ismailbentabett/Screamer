using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Screamer.Application.Dtos
{
    public class CoverDto
    {
           public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}