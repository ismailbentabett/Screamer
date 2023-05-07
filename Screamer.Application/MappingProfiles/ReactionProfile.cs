using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class ReactionProfile : Profile
    {
        public ReactionProfile()
        {
            CreateMap<Reaction, ReactionDto>().ReverseMap();
        }
    }
}