using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class CoverProfile : Profile
    {
        public CoverProfile()
        {

            CreateMap<Cover, CoverDto>().ReverseMap();

        }
    }
}