using MediatR;
using Microsoft.AspNetCore.Http;


namespace Screamer.Application.Features.AvatarRequest.Commands.CreateAvatarRequest
{
    public record SetMainAvatarRequestCommand :
    IRequest<
        int
    >
    {
    public  int avatarId;
    public  string userId;

    }
}