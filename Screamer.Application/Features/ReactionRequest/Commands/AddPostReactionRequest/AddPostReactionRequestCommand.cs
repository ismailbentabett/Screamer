using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest
{
    public class AddPostReactionRequestCommand : IRequest<PostReactionDto>
    {
        public string UserId { get; set; }
        public int? PostId { get; set; }

        public int? CommentId { get; set; }

        public string ReactionType { get; set; }

        public bool isPost { get; set; } = true;
    }
}
