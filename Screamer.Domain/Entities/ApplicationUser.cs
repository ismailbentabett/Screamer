using Microsoft.AspNetCore.Identity;
using Screamer.Domain;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Screamer.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Password { get; set; }

        public string Bio { get; set; }
        public string Website { get; set; }

        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Avatar> Avatars { get; set; } = new();
        public string AvatarUrl { get; set; }

        public ICollection<Post> Posts { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Message> MessagesSent { get; set; }
        public List<Message> MessagesReceived { get; set; }

        public List<Follow> Followers { get; set; } = new();
        public List<Follow> Following { get; set; } = new();

        public List<Cover> Covers { get; set; } = new();
        public string CoverUrl { get; set; }

        //chat rooms
        public ICollection<ChatRoomUser> ChatRoomUsers { get; set; } = new List<ChatRoomUser>();

        public Social Socials { get; set; }
        public Adress Adress { get; set; }

        public string ObjectID { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<BookMark> BookMarks { get; set; } = new List<BookMark>();
        public ICollection<PostMention> PostMentions { get; set; } = new List<PostMention>();
        public ICollection<CommentMention> CommentMentions { get; set; } =
            new List<CommentMention>();
    }
}
