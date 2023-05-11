using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.UserRequest.Queries;

    public record GetUserByUsernameRequestQuery : IRequest<UserDto>
    {
        public string Username { get; set; }
    }
