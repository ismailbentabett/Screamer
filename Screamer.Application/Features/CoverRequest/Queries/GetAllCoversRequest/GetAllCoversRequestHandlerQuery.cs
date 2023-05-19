using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.CoverRequest.Queries
{
    public class GetAllCoversRequestHandlerQuery : IRequestHandler<
        GetAllCoversRequestQuery,
        IEnumerable<CoverDto>
    >
    {
        private readonly ICoverRepository _coverRepository;
        private readonly IMapper _mapper;

        private readonly IAppLogger<GetAllCoversRequestHandlerQuery> _logger;

        public GetAllCoversRequestHandlerQuery(ICoverRepository coverRepository, IMapper mapper,
            IAppLogger<GetAllCoversRequestHandlerQuery> logger
        )
        {
            _coverRepository = coverRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CoverDto>> Handle(GetAllCoversRequestQuery request, CancellationToken cancellationToken)
        {
            var covers = await _coverRepository.GetAllAsync();
            _logger.LogInformation("GetAllAvatarsRequestHandlerQuery called");
            return _mapper.Map<IEnumerable<CoverDto>>(covers);
        }
    }
}