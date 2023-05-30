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
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest
{
    public class UpdatePostRequestHandlerCommand : IRequestHandler<UpdatePostRequestCommand, Unit>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;
        private readonly IAlgoliaService _algoliaService;

        public UpdatePostRequestHandlerCommand(
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
            UpdatePostRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var validator = new UpdatePostRequestCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid)
            {
                throw new BadRequestException(
                    $"Command validation errors for type {typeof(UpdatePostRequestCommand).Name}",
                    validationResult.Errors
                );
            }

            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            var post = await _postRepository.GetByIdAsync(request.postId);
            if (post == null)
                throw new NotFoundException(nameof(Post), request.postId.ToString());

            var postInputDto = _mapper.Map<PostInputDto>(request);
            _mapper.Map(postInputDto, post);

            await _uow.PostRepository.UpdateAsync(post);
            var posts = await _uow.PostRepository.GetAllAsync();
            await _algoliaService.AddAllPostsToIndex("post", posts);
            await _uow.Complete();
            return Unit.Value;
        }
    }
}
