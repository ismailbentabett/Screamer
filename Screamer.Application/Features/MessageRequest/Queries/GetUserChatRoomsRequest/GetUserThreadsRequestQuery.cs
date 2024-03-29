using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Presistance;

namespace Screamer.Application.Features.MessageRequest.Queries.GetUserChatRoomsRequest
{
    public class GetUserChatRoomsRequestQuery : IRequest<List<ChatRoomDto>>
    
    {
        public string userId
        {
            get;
            set;
        }

       public MessageParams messageParams;
    }
}
