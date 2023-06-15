using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostsByHashTagRequest
{
    public class GetPostsByHashTagRequestHandlerQuery
        : IRequestHandler<GetPostsByHashTagRequestQuery, List<PostDto>>
    {
        public Task<List<PostDto>> Handle(
            GetPostsByHashTagRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
