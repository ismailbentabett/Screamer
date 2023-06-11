using MediatR;
using Microsoft.AspNetCore.Http;

namespace Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest
{
    public record AddStoryImageRequestCommand : IRequest<int>
    {
        public IFormFile file;
        public int storyId;
    }
}
