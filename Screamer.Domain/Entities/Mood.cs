using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain.Entities
{
    public class Mood: BaseEntity
    {
    public string MoodType { get; set; }
    public ICollection<Post> Posts { get; set; }
    }
}