using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;

namespace Screamer.Application.Features.ReactionRequest.Commands.UpdateReactionRequest
{
    public class UpdateReactionRequestHandlerCommand
        : IRequestHandler<UpdateReactionRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UpdateReactionRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public Task<Unit> Handle(
            UpdateReactionRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
