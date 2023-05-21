using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.MessageRequest.Queries.GetChatRoomByIdRequest
{
    public class GetChatRoomByIdRequestQuery : IRequest<ChatRoomDto>
    {
        public int ChatRoomId { get; set; }
    }
}
