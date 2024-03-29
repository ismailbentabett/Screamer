using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostByUserIdRequest;

    public record GetPostByUserIdRequestQuery : IRequest<List<PostDto>>

    {
        
        public string UserId { get; set; }
                    public PostParams postParams { get; set; }

    }
