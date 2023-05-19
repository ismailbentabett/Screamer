using MediatR;
using Microsoft.AspNetCore.Http;


namespace Screamer.Application.Features.CoverRequest.Commands
{
    public record SetMainCoverRequestCommand :
    IRequest<
        int
    >
    {
    public  int coverId;
    public  string userId;

    }
}