using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.CommentRequest.Commands.AddReplyRequest
{
    public class AddReplyRequestCommand : IRequest<int>
    {
        public int ParentCommentId { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public int PostId { get; set; }

        public List<string> Hashtags { get; set; }
        public List<string> MentionsArr { get; set; }
    }
}
