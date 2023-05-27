using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.CommentRequest.Commands.UpdateCommentRequest
{
    public class UpdateCommentRequestCommand : IRequest<Unit>
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string Content { get; set; }
    }
}
