using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostsByCategoryRequest
{
    public class GetPostsByCategoryRequestHandlerQuery
        : IRequestHandler<GetPostsByCategoryRequestQuery, List<PostDto>>
    {
        public Task<List<PostDto>> Handle(
            GetPostsByCategoryRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
