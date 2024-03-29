using MediatR;
using Microsoft.AspNetCore.Http;


namespace Screamer.Application.Features.CoverRequest.Commands
{
    public record AddCoverRequestCommand :
    IRequest<
        int
    >
    {
    public  IFormFile file;
    public string userId;


    }
}