using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.PostRequest.Queries.GetPostsByHashTagRequest
{
    public class GetPostsByHashTagRequestHandlerQuery
        : IRequestHandler<GetPostsByHashTagRequestQuery, List<PostDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetPostsByHashTagRequestHandlerQuery(
            IPostRepository postRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<List<PostDto>> Handle(
            GetPostsByHashTagRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
