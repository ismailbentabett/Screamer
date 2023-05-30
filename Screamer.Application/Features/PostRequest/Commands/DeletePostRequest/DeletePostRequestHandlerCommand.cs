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
    public class DeletePostRequestHandlerCommand : IRequestHandler<DeletePostRequestCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;
        private readonly IAlgoliaService _algoliaService;

        public DeletePostRequestHandlerCommand(
            IPostRepository postRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IAlgoliaService algoliaService
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _uow = uow;
            _algoliaService = algoliaService;
        }

        public async Task<Unit> Handle(
            DeletePostRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var PostToDelete = await _uow.PostRepository.GetByIdAsync(request.postId);

            if (PostToDelete == null)
            {
                throw new NotFoundException(nameof(Post), request.postId.ToString());
            }
            await _uow.PostRepository.DeleteAsync(PostToDelete);
            var posts = await _uow.PostRepository.GetAllAsync();
            await _algoliaService.AddAllPostsToIndex("post", posts);
            await _uow.Complete();
            return Unit.Value;
        }
    }
}
