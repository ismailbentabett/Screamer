using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.BookMarkRequest.Queries.GetBookmarkByUserIdAndPostIdRequest
{
    public class GetBookmarkByUserIdAndPostIdRequestQuery : IRequest<Boolean>
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
