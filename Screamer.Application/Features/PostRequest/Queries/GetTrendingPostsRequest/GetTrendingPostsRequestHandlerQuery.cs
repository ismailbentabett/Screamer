using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetTrendingPostsRequest
{
    public class GetTrendingPostsRequestHandlerQuery
        : IRequestHandler<GetTrendingPostsRequestQuery, List<PostDto>>
    {
        public Task<List<PostDto>> Handle(
            GetTrendingPostsRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
