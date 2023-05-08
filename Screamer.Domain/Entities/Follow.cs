using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Domain
{
    public class Follow : BaseEntity
    {
        public int FollowerId { get; set; }
        [ForeignKey("FollowerId")]

        public User Follower { get; set; }
        public int FollowingId { get; set; }
        [ForeignKey("FollowingId")]

        public User Following { get; set; }
    }
}