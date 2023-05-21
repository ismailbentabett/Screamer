using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Screamer.Application.Contracts.Logging;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Presistance.Repositories;

namespace Screamer.Application.Features.MessageRequest.Queries.GetUserChatRoomsRequest
{
    public class GetUserChatRoomsRequestHandlerQuery: IRequestHandler<
        GetUserChatRoomsRequestQuery,
        List<ChatRoomDto>
    >
    {
     private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAppLogger<GetMessagesForUserRequestQuery> _logger;

        private readonly IHttpContextAccessor _httpContextAccessor;
    public GetUserChatRoomsRequestHandlerQuery(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAppLogger<GetMessagesForUserRequestQuery> logger,
        IHttpContextAccessor httpContextAccessor
        

    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<List<ChatRoomDto>> Handle(
        GetUserChatRoomsRequestQuery request,
        CancellationToken cancellationToken
    )
    {
        var messages = await _unitOfWork.MessageRepository.GetUserChatRooms(
            request.userId,
            request.messageParams
        );
        var messageDtos = _mapper.Map<List<ChatRoomDto>>(messages);
          HttpContext httpContext = _httpContextAccessor.HttpContext;
            HttpResponse Response = httpContext.Response;
            Response.AddPaginationHeader(new PaginationHeader(
                messages.CurrentPage,
                messages.PageSize,
                messages.TotalCount,
                messages.TotalPages
            ));
        return messageDtos;
    }
    }
}

  