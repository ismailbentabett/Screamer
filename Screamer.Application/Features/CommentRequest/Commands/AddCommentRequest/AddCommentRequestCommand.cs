using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.CommentRequest.Commands.AddCommentRequest
{
    public class AddCommentRequestCommand : IRequest<int>
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
    }
}
