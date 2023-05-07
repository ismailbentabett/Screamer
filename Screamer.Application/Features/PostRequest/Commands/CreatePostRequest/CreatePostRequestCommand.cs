using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.PostRequest.Commands.CreatePostRequest
{
    public record CreatePostRequestCommand :
    IRequest<
        int
    >
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public string ImageUrl { get; set; }
    }
}