using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.BookMarkRequest.Commands.AddBookMarkRequest
{
    public class AddBookMarkRequestCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
