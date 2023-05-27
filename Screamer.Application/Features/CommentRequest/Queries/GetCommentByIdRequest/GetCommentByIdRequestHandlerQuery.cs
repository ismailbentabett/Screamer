using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest;

namespace Screamer.Application.Features.CommentRequest.Queries.GetCommentByIdRequest
{
    public class GetCommentByIdRequestHandlerQuery
        : IRequestHandler<GetCommentByIdRequestQuery, CommentDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetCommentByIdRequestHandlerQuery> _logger;

        public GetCommentByIdRequestHandlerQuery(
            IUnitOfWork uow,
            IMapper mapper,
            IAppLogger<GetCommentByIdRequestHandlerQuery> logger
        )
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CommentDto> Handle(
            GetCommentByIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var comment = await _uow.CommentRepository.GetCommentById(request.CommentId);
            _logger.LogInformation("GetCommentByIdRequestHandlerQuery called");

            return _mapper.Map<CommentDto>(comment);
        }
    }
}
