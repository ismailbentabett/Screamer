using MediatR;
using Microsoft.AspNetCore.Http;


namespace Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest
{
    public record AddFollowRequestCommand :
    IRequest<
        int
    >
    {
        public string targetUserId;
        public string sourceUserId;
    }
}