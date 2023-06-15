using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetTheTopPreformingPostsRequest
{
    public class GetTheTopPreformingPostsRequestHandlerQuery
        : IRequestHandler<GetTheTopPreformingPostsRequestQuery, List<PostDto>>
    {
        public Task<List<PostDto>> Handle(
            GetTheTopPreformingPostsRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
