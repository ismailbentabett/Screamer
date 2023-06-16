using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;

namespace Screamer.Application.Features.BookMarkRequest.Queries.GetBookmarkByUserIdAndPostIdRequest
{
    public class GetBookmarkByUserIdAndPostIdRequestHandlerQuery
        : IRequestHandler<GetBookmarkByUserIdAndPostIdRequestQuery, Boolean>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public GetBookmarkByUserIdAndPostIdRequestHandlerQuery(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<bool> Handle(
            GetBookmarkByUserIdAndPostIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var bookmark = await _uow.BookMarkRepository.GetBookmarkByUserIdAndPostId(
                request.UserId,
                request.PostId
            );

            return bookmark is not null;
        }
    }
}
