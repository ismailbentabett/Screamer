using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.CommentRequest.Queries.GetRepliesByCommentIdRequest
{
    public class GetRepliesByCommentIdRequestQuery: IRequest<List<CommentDto>>
    {
 public CommentParams commentParams { get; set; }    }
}