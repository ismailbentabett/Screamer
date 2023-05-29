using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.ReactionRequest.Queries.GetPostReactionByPostAndUserRequest
{
    public class GetPostReactionByPostAndUserRequestQuery : IRequest<PostReactionDto>
    {
        public int PostId { get; set; }
        public string UserId { get; set; }
    }
}
