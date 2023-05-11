using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.AvatarRequest.Commands.UpdateAvatarRequest
{
    public class UpdateAvatarRequestCommand 
: IRequest<Unit>
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
}
}