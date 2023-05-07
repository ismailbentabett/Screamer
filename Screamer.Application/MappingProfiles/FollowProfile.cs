using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Domain;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class FollowProfile : Profile
    {
        public FollowProfile()
        {
            CreateMap<Follow, FollowDto>().ReverseMap();
        }
    }
}