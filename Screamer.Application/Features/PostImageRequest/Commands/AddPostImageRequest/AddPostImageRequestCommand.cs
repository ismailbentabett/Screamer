using MediatR;
using Microsoft.AspNetCore.Http;

namespace Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest
{
    public record AddPostImageRequestCommand : IRequest<int>
    {
        public IFormFile file;
        public int postId;
    }
}
