using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.AvatarRequest.Queries.GetAvatarByIdRequest;

namespace Screamer.Application.Features.CoverRequest.Queries
{
    public class GetCoverByIdRequestHandlerQuery : IRequestHandler<
        GetCoverByIdRequestQuery, CoverDto
     >
    {
        private readonly ICoverRepository _coverRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<GetCoverByIdRequestHandlerQuery> _logger; 

        public GetCoverByIdRequestHandlerQuery(ICoverRepository coverRepository, IMapper mapper , 
            IAppLogger<GetCoverByIdRequestHandlerQuery> logger
        )
        {
            _coverRepository = coverRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<CoverDto> Handle(GetCoverByIdRequestQuery request, CancellationToken cancellationToken)
        {
            var cover = await _coverRepository.GetByIdAsync(request.Id);
            _logger.LogInformation("GetCoverByIdRequestHandlerQuery called");
            return _mapper.Map<CoverDto>(cover);
        }
    }
}