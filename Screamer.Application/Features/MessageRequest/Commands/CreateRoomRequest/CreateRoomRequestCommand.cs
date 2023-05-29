using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.MessageRequest.Commands.CreateRoomRequest
{
    public class CreateRoomRequestCommand : IRequest<int>
    {
        public string userId { get; set; }
        public string recipientId { get; set; }
    }
}
