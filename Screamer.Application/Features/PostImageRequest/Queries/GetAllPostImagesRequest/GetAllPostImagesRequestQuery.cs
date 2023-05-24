using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;

namespace Screamer.Application.Features.postImageRequest.Queries;

public record GetAllPostImagesRequestQuery : IRequest<List<PostImageDto>>;
