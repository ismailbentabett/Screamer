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

namespace Screamer.Application.Features.BookMarkRequest
{
    public class AddBookMarkRequestHandlerCommand : IRequestHandler<AddBookMarkRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddBookMarkRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            AddBookMarkRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            var post = await _uow.PostRepository.GetPostById(request.PostId);
            if (post == null)
                throw new NotFoundException(nameof(Post), request.PostId);

            var ExistingBookMark = await _uow.BookMarkRepository.GetBookmarkByUserIdAndPostId(
                request.UserId,
                post.Id
            );
            if (ExistingBookMark != null)
                throw new BadRequestException("This post is already bookmarked");

            var bookMark = new BookMark
            {
                PostId = request.PostId,
                UserId = request.UserId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _uow.BookMarkRepository.AddAsync(bookMark);

            await _uow.Complete();

            return bookMark.Id;
        }
    }
}
