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
        public List<string> Categories { get; set; }
        public List<string> Hashtags { get; set; }
        public List<string> TagsTaaZabi { get; set; }

        public string MoodType { get; set; }
    }
}
