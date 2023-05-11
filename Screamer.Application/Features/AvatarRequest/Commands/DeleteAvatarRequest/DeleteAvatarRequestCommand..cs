using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.AvatarRequest.Commands.DeleteAvatarRequest
{
    public class DeleteAvatarRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}