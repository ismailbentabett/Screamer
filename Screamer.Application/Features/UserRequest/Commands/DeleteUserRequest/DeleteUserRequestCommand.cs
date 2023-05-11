using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Screamer.Application.Features.UserRequest.Commands.DeleteUserRequest
{
    public class DeleteUserRequestCommand : IRequest<Unit>
    {
        public string Id { get; set; }
    }
}