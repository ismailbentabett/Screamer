using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.ReactionRequest.Queries.GetCommentReactionByCommentAndUserRequest
{
    public class GetCommentReactionByCommentAndUserRequestHandlerQuery
        : IRequestHandler<GetCommentReactionByCommentAndUserRequestQuery, CommentReactionDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetCommentReactionByCommentAndUserRequestHandlerQuery> _logger;

        public GetCommentReactionByCommentAndUserRequestHandlerQuery(
            IUnitOfWork uow,
            IMapper mapper,
            IAppLogger<GetCommentReactionByCommentAndUserRequestHandlerQuery> logger
        )
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public Task<CommentReactionDto> Handle(
            GetCommentReactionByCommentAndUserRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);

            var comment = _uow.CommentRepository.GetCommentById((int)request.CommentId);
            if (comment == null)
                throw new NotFoundException(nameof(Comment), (int)request.CommentId);

            var commentReaction = _uow.ReactionRepository.GetCommentReactionByCommentAndUser(
                request.CommentId,
                request.UserId
            );
            if (commentReaction == null)
                throw new NotFoundException(nameof(CommentReaction), (int)request.CommentId);

                
            return Task.FromResult(_mapper.Map<CommentReactionDto>(commentReaction));
        }
    }
}
