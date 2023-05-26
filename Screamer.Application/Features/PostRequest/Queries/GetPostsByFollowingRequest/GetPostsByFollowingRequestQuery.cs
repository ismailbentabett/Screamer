using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostsByFollowingRequest
{
    public class GetPostsByFollowingRequestQuery: IRequest<List<PostDto>>
    {
        public string userId { get; set; }
        public RecommendationParams recommendationParams { get; set; }
    }
}
