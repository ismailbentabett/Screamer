using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Screamer.Domain.Entities;
using Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest;

namespace Screamer.Application.Features.postImageRequest.Commands
{
    public class AddPostImageRequestHandlerCommand
        : IRequestHandler<AddPostImageRequestCommand, int>
    {
        private readonly IPostImageRepository _postImageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddPostImageRequestHandlerCommand(
            IPostImageRepository postImageRepository,
            IMapper mapper,
            IUnitOfWork uow
        )
        {
            _postImageRepository = postImageRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            AddPostImageRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var post = await _uow.PostRepository.GetPostById(request.postId);

            if (post == null)
                throw new NotFoundException(nameof(Post), request.postId);

            var result = await _postImageRepository.AddPhotoAsync(request.file);

            if (result.Error != null)
                throw new BadRequestException(result.Error.Message);

            var postImage = new PostImage
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (post.PostImages.Count == 0)
                postImage.IsMain = true;

            post.PostImages.Add(postImage);

            if (await _uow.Complete())
            {
                return postImage.Id;
            }

            throw new BadRequestException("Problem adding photo");
        }
    }
}
