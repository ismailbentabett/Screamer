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

        public async Task<Unit> Handle(
            RemoveReactionRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            if (request.isPost == true)
            {
                var reaction = _uow.ReactionRepository.GetPostReactionById(request.ReactionId);
                if (reaction == null)
                    throw new NotFoundException(nameof(PostReaction), request.ReactionId);

                _uow.ReactionRepository.RemovePostReaction(reaction);

                if (await _uow.Complete())
                {
                    return await Task.FromResult(Unit.Value);
                }
                else
                {
                    throw new Exception("Problem saving changes");
                }
            }
            else if (request.isPost == false)
            {
                var reaction = _uow.ReactionRepository.GetCommentReactionById(request.ReactionId);
                if (reaction == null)
                    throw new NotFoundException(nameof(CommentReaction), request.ReactionId);
                _uow.ReactionRepository.RemoveCommentReaction(reaction);
                if (await _uow.Complete())
                {
                    return await Task.FromResult(Unit.Value);
                }
                else
                {
                    throw new Exception("Problem saving changes");
                }
            }

            throw new Exception("Problem saving changes");
        }
    }
}
