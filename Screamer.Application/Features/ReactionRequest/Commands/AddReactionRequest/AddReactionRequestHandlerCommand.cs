using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;

namespace Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest
{
    public class AddReactionRequestHandlerCommand : IRequestHandler<AddReactionRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddReactionRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public Task<int> Handle(
            AddReactionRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
