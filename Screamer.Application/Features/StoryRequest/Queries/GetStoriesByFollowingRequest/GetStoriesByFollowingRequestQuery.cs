using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.StoryRequest{
    public record GetStoriesByFollowingRequestQuery: IRequest<List<StoryDto>> 
    {
            public string UserId { get; set; }
    }
}