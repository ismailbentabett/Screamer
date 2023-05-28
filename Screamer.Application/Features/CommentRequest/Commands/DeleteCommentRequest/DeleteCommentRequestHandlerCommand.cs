using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.CommentRequest.Commands.DeleteCommentRequest
{
    public class DeleteCommentRequestHandlerCommand
        : IRequestHandler<DeleteCommentRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public DeleteCommentRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Unit> Handle(
            DeleteCommentRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            var post = await _uow.PostRepository.GetPostById(request.PostId);
            if (post == null)
                    throw new NotFoundException(nameof(Post), request.PostId);

            var comment = await _uow.CommentRepository.GetCommentById(request.CommentId);
            if (comment == null)
                throw new NotFoundException(nameof(Comment), request.CommentId);

            _uow.CommentRepository.RemoveComment(comment);

            if (await _uow.Complete())
                return Unit.Value;

            throw new Exception("Problem saving changes");
        }
    }
}
