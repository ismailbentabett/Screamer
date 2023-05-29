using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.ReactionRequest.Queries.GetCommentReactionByCommentAndUserRequest
{
    public class GetCommentReactionByCommentAndUserRequestQuery : IRequest<CommentReactionDto>
    {
        public int CommentId { get; set; }
        public string UserId { get; set; }
    }
}
