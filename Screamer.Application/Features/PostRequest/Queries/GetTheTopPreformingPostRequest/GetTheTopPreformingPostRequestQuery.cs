using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;

namespace Screamer.Application.Features.PostRequest.Queries.GetTheTopPreformingPostRequest
{
    public class GetTheTopPreformingPostRequestQuery : IRequest<PostDto>
    {
        
    }
}