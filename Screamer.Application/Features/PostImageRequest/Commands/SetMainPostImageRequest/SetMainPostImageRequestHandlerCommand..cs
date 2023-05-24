using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.postImageRequest.Commands
{
    public class SetMainPostImageRequestHandlerCommand
        : IRequestHandler<SetMainPostImageRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SetMainPostImageRequestHandlerCommand(
            IMapper mapper,
            IUnitOfWork uow
        )
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            SetMainPostImageRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var post = await _uow.PostRepository.GetByIdAsync(request.postId);

            if (post == null)
                throw new NotFoundException(nameof(Post), request.postId);

            var postImage = post.PostImages.FirstOrDefault(x => x.Id == request.postImageId);

            if (postImage == null)
                throw new NotFoundException(nameof(PostImage), request.postId);

            if (postImage.IsMain)
                throw new BadRequestException("this is already your main photo");

            var currentMain = post.PostImages.FirstOrDefault(x => x.IsMain);
            if (currentMain != null)
                currentMain.IsMain = false;
            postImage.IsMain = true;
            if (await _uow.Complete())
            {
                return postImage.Id;
            }
            else
            {
                throw new Exception("problem saving changes");
            }
        }
    }
}
