using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.BookMarkRequest.Commands.UpdateBookMarkRequest
{
    public class UpdateBookMarkRequestCommand : IRequest<Unit>
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
        public int BookMarkId { get; set; }
    }
}
