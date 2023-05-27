using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.CommentRequest.Queries.GetCommentByIdRequest
{
    public class GetCommentByIdRequestQuery : IRequest<CommentDto>
    {
        public int CommentId { get; set; }
    }
}
