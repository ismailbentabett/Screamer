using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.AvatarRequest.Commands.CreateAvatarRequest
{
    public record CreateAvatarRequestCommand :
    IRequest<
        int
    >
    {
      public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
     /*    [ForeignKey("UserId")]
        public User User { get; set; } */
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reaction> Reactions { get; set; } 
        public int Views { get; set; }
    }
}