using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetAllPostsRequest;
    public record GetAllPostsRequestQuery : IRequest<List<PostDto>>;
