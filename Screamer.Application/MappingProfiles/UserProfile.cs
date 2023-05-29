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
            CreateMap<ApplicationUser, UserDto>()
                 .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.Avatars.LastOrDefault().Url))
                .ForMember(dest => dest.Avatars, opt => opt.MapFrom(src => src.Avatars))
                .ForMember(dest => dest.CoverUrl, opt => opt.MapFrom(src => src.Covers.LastOrDefault().Url))
                .ForMember(dest => dest.Covers, opt => opt.MapFrom(src => src.Covers));

            CreateMap<UpdateUserRequestCommand, UpdateUserDto>().ReverseMap();
            CreateMap<UpdateUserRequestCommand, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, UpdateUserDto>().ReverseMap();
            CreateMap<UpdateUserDto, UserDto>().ReverseMap();

            CreateMap<DeleteUserRequestCommand, ApplicationUser>().ReverseMap();
            CreateMap<SocialDto, Social>().ReverseMap();
            CreateMap<AdressDto, Adress>().ReverseMap();



        }
    }
}