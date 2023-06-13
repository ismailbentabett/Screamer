using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.StoryRequest{
    public class GetAllStoriesRequestQuery
        : IRequestHandler<GetAllStoriesRequestHandlerQuery, List<StoryDto>>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public GetAllStoriesRequestQuery(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<List<StoryDto>> Handle(
            GetAllStoriesRequestHandlerQuery request,
            CancellationToken cancellationToken
        )
        {
            var data = await _uow.StoryRepository.GetAllStoriesAsync();
            return _mapper.Map<List<StoryDto>>(data);
        }
    }
}
