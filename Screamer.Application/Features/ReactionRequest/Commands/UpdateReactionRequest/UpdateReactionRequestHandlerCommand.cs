using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.ReactionRequest.Commands.UpdateReactionRequest
{
    public class UpdateReactionRequestHandlerCommand
        : IRequestHandler<UpdateReactionRequestCommand, Unit>
    {
        public Task<Unit> Handle(UpdateReactionRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
