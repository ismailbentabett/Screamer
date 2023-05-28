using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest
{
    public class AddReactionRequestCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public int PostId { get; set; }

        public int CommentId { get; set; }

        public string ReactionType { get; set; }

        public bool isPost { get; set; }
    }
}
