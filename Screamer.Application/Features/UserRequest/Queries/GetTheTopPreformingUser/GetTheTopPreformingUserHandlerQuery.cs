using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.UserRequest.Queries.GetTheTopPreformingUser
{
    public class GetTheTopPreformingUserHandlerQuery
        : IRequestHandler<GetTheTopPreformingUserQuery, UserDto>
    {
        public Task<UserDto> Handle(
            GetTheTopPreformingUserQuery request,
            CancellationToken cancellationToken
        )
        {
            throw new NotImplementedException();
        }
    }
}
