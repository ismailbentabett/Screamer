using MediatR;
using Microsoft.AspNetCore.Http;

namespace Screamer.Application.Features.postImageRequest.Commands
{
    public record AddPostImageRequestCommand : IRequest<int>
    {
        public IFormFile file;
        public int postId;
    }
}
