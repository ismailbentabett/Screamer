using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Queries;
    public record GetUsersRequestQuery : IRequest<List<UserDto>>{
            public UserParams userParams { get; set; }

            public string userId { get; set; }

    }
    
