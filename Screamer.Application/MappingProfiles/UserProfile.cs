using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
            public UserProfile()
            {
                CreateMap<User, UserDto>().ReverseMap();
              
            }
    }
}