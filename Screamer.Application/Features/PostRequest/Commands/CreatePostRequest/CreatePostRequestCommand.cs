using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.PostRequest.Commands.CreatePostRequest
{
    public record CreatePostRequestCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
        public List<string> CategoryNames { get; set; }
        public List<string> Hashtags { get; set; } 
        public Mood mood { get; set; }
    }
}
