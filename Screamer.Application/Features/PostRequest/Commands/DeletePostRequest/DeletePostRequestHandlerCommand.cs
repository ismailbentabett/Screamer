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

        public DeletePostRequestHandlerCommand(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

    public async Task<Unit> Handle(DeletePostRequestCommand request, CancellationToken cancellationToken)
        {
          
      var PostToDelete = await _postRepository.GetByIdAsync(request.Id);

            // verify that record exists
            if (PostToDelete == null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }

            // remove from database
            await _postRepository.DeleteAsync(PostToDelete);

            // retun record id
            return Unit.Value;
    }
}
}