using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain
{
    public class Follow : BaseEntity
    {
        public string? FollowingId { get; set; }
        public User? Follower { get; set; }
        public string? FollowerId { get; set; }
        public User? Following { get; set; }
    }
}