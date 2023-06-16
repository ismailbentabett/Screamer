using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.UserRequest.Queries.GetTheTopPreformingUser
{
    public class GetTheTopPreformingUserQuery : IRequest<UserDto>
    {
        public string currentUserId { get; set; }
    }
}