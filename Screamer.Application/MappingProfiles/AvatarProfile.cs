using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Application.Features.PostRequest.Commands.CreatePostRequest;
using Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class AvatarProfile : Profile
    {
        public AvatarProfile()
        {

            CreateMap<Avatar, AvatarDto>().ReverseMap();
    
        
        }
    }
}