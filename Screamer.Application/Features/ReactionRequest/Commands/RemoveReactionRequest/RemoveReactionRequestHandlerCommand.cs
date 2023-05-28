using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.ReactionRequest.Commands.RemoveReactionRequest
{
    public class RemoveReactionRequestHandlerCommand
        : IRequestHandler<RemoveReactionRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public RemoveReactionRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public Task<Unit> Handle(
            RemoveReactionRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var reaction = _uow.ReactionRepository.GetReactionById(request.ReactionId);

            if (reaction == null)
                throw new NotFoundException(nameof(Reaction), request.ReactionId);

            _uow.ReactionRepository.RemoveReaction(reaction);

            return Task.FromResult(Unit.Value);
        }
    }
}
