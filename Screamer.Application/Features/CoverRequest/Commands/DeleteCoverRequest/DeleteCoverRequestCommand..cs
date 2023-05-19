using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.AvatarRequest.Commands.DeleteAvatarRequest
{
    public class DeleteCoverRequestCommand : IRequest<Unit>
    {
        public int coverId { get; set; }
        public string userId { get; set; }
    }
}