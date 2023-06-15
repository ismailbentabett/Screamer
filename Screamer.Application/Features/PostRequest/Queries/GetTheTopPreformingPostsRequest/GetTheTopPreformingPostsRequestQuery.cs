using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.PostRequest.Queries.GetTheTopPreformingPostsRequest
{
    public class GetTheTopPreformingPostsRequestQuery : IRequest<List<PostDto>>
    {
        public PostParams postParams { get; set; }
    }
}
