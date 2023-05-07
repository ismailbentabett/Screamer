using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.PostRequest.Commands.DeletePostRequest
{
    public class DeletePostRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}