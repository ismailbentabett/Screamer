using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.StoryRequest.Commands.DeleteStoryRequest
{
    public class DeleteStoryRequestCommand: IRequest<Unit>
    {
        public int storyId { get; set; }
    }
}