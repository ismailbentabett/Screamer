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

namespace Screamer.Application.Features.CommentRequest.Commands.AddCommentRequest
{
    public class AddCommentRequestHandlerCommand : IRequestHandler<AddCommentRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddCommentRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            AddCommentRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            //check if post exist
            var post = await _uow.PostRepository.GetPostById(request.PostId);
            if (post == null)
                if (user == null)
                    throw new NotFoundException(nameof(Post), request.PostId);

            Comment comment = new Comment
            {
                PostId = request.PostId,
                UserId = request.UserId,
                Content = request.Content,
                CreatedAt = DateTime.Now,
                User = user,
                Post = post
            };

            _uow.CommentRepository.AddComment(comment);

            if (await _uow.Complete())
            {
                return comment.Id;
            }

            throw new BadRequestException("Problem adding Cotmmen");
        }
    }
}
