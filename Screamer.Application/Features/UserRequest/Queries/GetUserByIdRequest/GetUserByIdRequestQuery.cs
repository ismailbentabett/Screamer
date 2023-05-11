using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Queries;
    public record GetUserByIdRequestQuery : IRequest<UserDto>
    {
        public string Id { get; set; }
    }
