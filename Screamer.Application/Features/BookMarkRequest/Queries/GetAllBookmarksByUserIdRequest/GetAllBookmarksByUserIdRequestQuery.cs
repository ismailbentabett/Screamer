using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Helpers;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.BookMarkRequest.Queries.GetAllBookmarksByUserId
{
    public class GetAllBookmarksByUserIdRequestQuery : IRequest<List<BookMark>>{
            public PostParams postParams { get; set; }


         
    }
}