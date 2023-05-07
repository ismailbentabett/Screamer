using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostRequest;

    public record GetPostByIdRequestQuery : IRequest<PostDto>
    {
        public int Id { get; set; }
    }
