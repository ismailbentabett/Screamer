using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Domain.Entities
{
    public class Message : BaseEntity
    {
        public int SenderId { get; set; }
        public string SenderUsername { get; set; }
        public  ApplicationUser Sender { get; set; }
        public int RecipientId { get; set; }
        public string RecipientUsername { get; set; }
        public ApplicationUser Recipient { get; set; }
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.UtcNow;
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
    }
}