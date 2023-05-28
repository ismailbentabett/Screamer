using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest
{
    public class AddReactionRequestHandlerCommand :
    IRequestHandler<
        AddReactionRequestCommand,
        int
    >
    {
        public Task<int> Handle(AddReactionRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}