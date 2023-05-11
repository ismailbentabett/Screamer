using MediatR;
using Microsoft.AspNetCore.Http;


namespace Screamer.Application.Features.AvatarRequest.Commands.CreateAvatarRequest
{
    public record CreateAvatarRequestCommand :
    IRequest<
        int
    >
    {
    public  IFormFile file;
    public int userId;
    }
}