using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostByUserIdRequest;

    public record GetPostByUserIdRequestQuery : IRequest<PostDto>

    {
        public int UserId { get; set; }
    }
