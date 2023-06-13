using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.BookMarkRequest.Queries.GetAllBookmarksByUserId
{
    public class GetAllBookmarksByUserIdRequestHandlerQuery
        : IRequestHandler<GetAllBookmarksByUserIdRequestQuery, List<BookMark>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public GetAllBookmarksByUserIdRequestHandlerQuery(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public Task<List<BookMark>> Handle(
            GetAllBookmarksByUserIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
