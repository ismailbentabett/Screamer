using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.StoryImageRequest
{
    public class DeleteStoryImageRequestCommand : IRequest<Unit>
    {
        public int storyImageId { get; set; }
        public int storyId { get; set; }
    }
}