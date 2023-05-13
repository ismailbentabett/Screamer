using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Application.Features.PostRequest.Commands.UpdateUserRequest;
using Screamer.Application.Features.UserRequest.Commands.DeleteUserRequest;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
            public UserProfile()
            {
                CreateMap<ApplicationUser, UserDto>().ReverseMap()
                 .ForMember(dest => dest.AvatarUrl, 
                    opt => opt.MapFrom(src => src.Avatars.FirstOrDefault(x => x.IsMain).Url));
                CreateMap<UpdateUserRequestCommand, ApplicationUser>().ReverseMap();
                CreateMap<DeleteUserRequestCommand, ApplicationUser>().ReverseMap();
       

              
            }
    }
}