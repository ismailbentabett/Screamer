using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.postImageRequest.Commands
{
    public class DeletePostImageRequestCommand : IRequest<Unit>
    {
        public int postImageId { get; set; }
        public int postId;
    }
}
