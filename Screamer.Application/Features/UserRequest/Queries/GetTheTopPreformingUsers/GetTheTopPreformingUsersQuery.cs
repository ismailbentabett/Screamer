using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.Application.Features.UserRequest.Queries.GetTheTopPreformingUsers
{
    public class GetTheTopPreformingUsersQuery : IRequest<List<UserDto>>
    {
        public UserParams userParams { get; set; }
    }
}
