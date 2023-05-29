using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest
{
    public class AddCommentReactionRequestHandlerCommand
        : IRequestHandler<AddCommentReactionRequestCommand, CommentReactionDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddCommentReactionRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<CommentReactionDto> Handle(
            AddCommentReactionRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);

            var comment = await _uow.CommentRepository.GetCommentById((int)request.CommentId);
            if (comment == null)
                throw new NotFoundException(nameof(Comment), (int)request.CommentId);

            var reaction = new CommentReaction
            {
                CommentId = (int)request.CommentId,
                UserId = request.UserId,
                ReactionType = request.ReactionType,
                CreatedAt = DateTime.Now,
                User = user,
                Comment = comment
            };

            _uow.ReactionRepository.AddCommentReaction(reaction);

            if (await _uow.Complete())
            {
                return _mapper.Map<CommentReactionDto>(reaction);
            }

            throw new BadRequestException("Problem adding Reaction");
        }
    }
}
