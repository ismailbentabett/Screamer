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

namespace Screamer.Application.Features.CommentRequest.Commands.UpdateCommentRequest
{
    public class UpdateCommentRequestHandlerCommand
        : IRequestHandler<UpdateCommentRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UpdateCommentRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Unit> Handle(
            UpdateCommentRequestCommand request,
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

            comment.Content = request.Content;
            comment.UpdatedAt = DateTime.Now;
            await _uow.CommentRepository.UpdateAsync(comment);
            return Unit.Value;
        }
    }
}
