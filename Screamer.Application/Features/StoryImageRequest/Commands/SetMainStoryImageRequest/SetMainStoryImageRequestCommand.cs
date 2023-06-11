using MediatR;
using Microsoft.AspNetCore.Http;


namespace Screamer.Application.Features.StoryImageRequest
{
    public record SetMainStoryImageRequestCommand :
    IRequest<
        int
    >
    {
   public int storyImageId { get; set; }
        public int storyId;

    }
}