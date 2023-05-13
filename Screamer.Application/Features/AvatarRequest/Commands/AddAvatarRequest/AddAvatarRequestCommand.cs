using MediatR;
using Microsoft.AspNetCore.Http;


namespace Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest
{
    public record AddAvatarRequestCommand :
    IRequest<
        int
    >
    {
    public  IFormFile file;
    public string userId;


    }
}