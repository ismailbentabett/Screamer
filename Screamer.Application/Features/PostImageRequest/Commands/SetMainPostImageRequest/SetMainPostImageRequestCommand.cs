using MediatR;
using Microsoft.AspNetCore.Http;


namespace Screamer.Application.Features.postImageRequest.Commands
{
    public record SetMainPostImageRequestCommand :
    IRequest<
        int
    >
    {
   public int postImageId { get; set; }
        public int postId;

    }
}