using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;

namespace Screamer.Application.Features.PostRequest.Commands.DeletePostRequest
{
    public class DeletePostRequestHandlerCommand :
    IRequestHandler
    <
        DeletePostRequestCommand,
        Unit
        >
    {
        private readonly IPostRepository _postRepository;
        private readonly IUnitOfWork _uow;


        public DeletePostRequestHandlerCommand(IPostRepository postRepository,
            IUnitOfWork uow
        )
        {
            _postRepository = postRepository;
            _uow = uow;
        }

        public async Task<Unit> Handle(DeletePostRequestCommand request, CancellationToken cancellationToken)
        {

            var PostToDelete =
                  await _uow
                      .PostRepository
                      .GetByIdAsync(request.postId);

            if (PostToDelete == null)
            {
                throw new NotFoundException(nameof(Post), request.postId.ToString());
            }
            await _uow.PostRepository.DeleteAsync(PostToDelete);
            await _uow.Complete();
            return Unit.Value;

        }
    }
}