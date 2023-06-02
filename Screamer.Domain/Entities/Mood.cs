using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain.Entities
{
    public class Mood: BaseEntity
    {
          public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Post> Posts { get; set; }
    }
}