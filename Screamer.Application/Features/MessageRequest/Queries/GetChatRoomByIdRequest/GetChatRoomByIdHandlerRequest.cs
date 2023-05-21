using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.MessageRequest.Queries.GetChatRoomByIdRequest
{
    public class GetChatRoomByIdHandlerRequest
        : IRequestHandler<GetChatRoomByIdRequestQuery, ChatRoomDto>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetChatRoomByIdHandlerRequest(IMapper mapper, IUnitOfWork uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ChatRoomDto> Handle(
            GetChatRoomByIdRequestQuery request,
            CancellationToken cancellationToken
        )
        {
            var room = await _uow.MessageRepository.GetChatRoomById(request.ChatRoomId);
            return _mapper.Map<ChatRoomDto>(room);
        }
    }
}
