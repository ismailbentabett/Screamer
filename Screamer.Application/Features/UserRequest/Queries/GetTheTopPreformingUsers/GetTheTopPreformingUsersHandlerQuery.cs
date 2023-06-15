using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.UserRequest.Queries.GetTheTopPreformingUsers
{
    public class GetTheTopPreformingUsersHandlerQuery
        : IRequestHandler<GetTheTopPreformingUsersQuery, List<UserDto>>
    {
        public Task<List<UserDto>> Handle(
            GetTheTopPreformingUsersQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
