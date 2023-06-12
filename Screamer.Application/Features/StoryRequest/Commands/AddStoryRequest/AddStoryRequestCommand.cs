using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.StoryRequest.Commands.AddStoryRequest
{
    public class AddStoryRequestCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string UserId { get; set; }
    }
}
