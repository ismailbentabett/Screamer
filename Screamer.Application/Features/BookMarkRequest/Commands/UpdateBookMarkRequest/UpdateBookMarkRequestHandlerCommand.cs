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
    public class UpdateBookMarkRequestHandlerCommand
        : IRequestHandler<UpdateBookMarkRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public UpdateBookMarkRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Unit> Handle(
            UpdateBookMarkRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);
            var post = await _uow.PostRepository.GetPostById(request.PostId);
            if (post == null)
                throw new NotFoundException(nameof(Post), request.PostId);

            var bookMark = await _uow.BookMarkRepository.GetBookmarkByUserIdAndPostId(
                request.UserId,
                request.PostId
            );
            if (bookMark == null)
                throw new NotFoundException(nameof(BookMark), bookMark.Id);

            bookMark.PostId = request.PostId;
            bookMark.UserId = request.UserId;

            bookMark.UpdatedAt = DateTime.Now;
            bookMark.CreatedAt = DateTime.Now;

            await _uow.BookMarkRepository.UpdateAsync(bookMark);

            await _uow.Complete();

            return Unit.Value;
        }
    }
}
