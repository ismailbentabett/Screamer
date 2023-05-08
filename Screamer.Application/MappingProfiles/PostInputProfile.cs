using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;

namespace Screamer.Application.MappingProfiles
{
    public class PostInputProfile : Profile
    {
        public PostInputProfile() =>CreateMap<PostInputDto, PostDto>().ReverseMap();


    }
}