using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.FollowRequest.Commands.RemoveFollowRequest
{
    public class RemoveFollowRequestCommand :
    IRequest<
        Unit
    >
    {
        public string targetUserId;
        public string sourceUserId;
    }
}