using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.ReactionRequest.Queries.GetPostReactionByPostAndUserRequest
{
    public class GetPostReactionByPostAndUserRequestHandlerQuery
        : IRequestHandler<GetPostReactionByPostAndUserRequestQuery, PostReactionDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetPostReactionByPostAndUserRequestHandlerQuery> _logger;

        public GetPostReactionByPostAndUserRequestHandlerQuery(
            IUnitOfWork uow,
            IMapper mapper,
            IAppLogger<GetPostReactionByPostAndUserRequestHandlerQuery> logger
        )
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PostReactionDto> Handle(
            GetPostReactionByPostAndUserRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);

            var post = await _uow.PostRepository.GetPostById((int)request.PostId);
            if (post == null)
                throw new NotFoundException(nameof(Post), (int)request.PostId);

            var postReaction = await _uow.ReactionRepository.GetPostReactionByPostAndUser(
                request.PostId,
                request.UserId
            );

            return _mapper.Map<PostReactionDto>(postReaction);
        }
    }
}
