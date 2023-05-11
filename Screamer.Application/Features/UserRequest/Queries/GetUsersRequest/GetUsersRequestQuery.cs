using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.UserRequest.Queries.GetUsersRequest;
    public record GetUsersRequestQuery : IRequest<List<UserDto>>;
