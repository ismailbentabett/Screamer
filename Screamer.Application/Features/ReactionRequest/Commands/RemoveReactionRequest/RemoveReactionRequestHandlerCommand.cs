using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.ReactionRequest.Commands.RemoveReactionRequest
{
    public class RemoveReactionRequestHandlerCommand :
        IRequestHandler<
            RemoveReactionRequestCommand,
            Unit
            >
    {
        public Task<Unit> Handle(RemoveReactionRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}