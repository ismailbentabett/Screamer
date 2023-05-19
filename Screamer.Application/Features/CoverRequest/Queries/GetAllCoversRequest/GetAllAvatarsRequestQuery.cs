using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.AvatarRequest.Queries.GetAllAvatarsRequest;
    public record GetAllAvatarsRequestQuery : IRequest<List<AvatarDto>>;
