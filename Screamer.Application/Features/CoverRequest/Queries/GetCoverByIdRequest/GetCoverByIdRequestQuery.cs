using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.CoverRequest.Queries;

    public record GetCoverByIdRequestQuery : IRequest<CoverDto>
    {
        public int Id { get; set; }
    }
