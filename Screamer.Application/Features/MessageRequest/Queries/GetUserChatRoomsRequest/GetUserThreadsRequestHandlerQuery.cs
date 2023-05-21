using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.MessageRequest.Queries.GetUserChatRoomsRequest
{
    public class GetUserChatRoomsRequestHandlerQuery: IRequestHandler<
        GetUserChatRoomsRequestQuery,
        List<ChatRoomDto>
    >
    {
    private IUnitOfWork     
        _unitOfWork;
    private IMapper _mapper;
    public GetUserChatRoomsRequestHandlerQuery(
        IUnitOfWork unitOfWork,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<List<ChatRoomDto>> Handle(
        GetUserChatRoomsRequestQuery request,
        CancellationToken cancellationToken
    )
    {
        var messages = await _unitOfWork.MessageRepository.GetUserChatRooms(
            request.userId
        );
        var messageDtos = _mapper.Map<List<ChatRoomDto>>(messages);
        return messageDtos;
    }
    }
}

  