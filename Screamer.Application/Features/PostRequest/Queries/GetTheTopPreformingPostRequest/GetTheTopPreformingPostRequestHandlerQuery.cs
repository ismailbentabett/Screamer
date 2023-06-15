using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetTheTopPreformingPostRequest
{
    public class GetTheTopPreformingPostRequestHandlerQuery
        : IRequestHandler<GetTheTopPreformingPostRequestQuery, PostDto>
    {
        public Task<PostDto> Handle(
            GetTheTopPreformingPostRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
