using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Application.Features.StoryImageRequest;
using Screamer.Application.Features.StoryRequest.Commands.AddStoryRequest;
using Screamer.Application.Features.StoryRequest.Commands.DeleteStoryRequest;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class StoryProfile : Profile
    {
        public StoryProfile()
        {
            CreateMap<DeleteStoryRequestCommand, Story>().ReverseMap();
            CreateMap<AddStoryRequestCommand, Story>().ReverseMap();
            CreateMap<AddStoryImageRequestCommand, StoryImage>().ReverseMap();
            CreateMap<DeleteStoryImageRequestCommand, StoryImage>().ReverseMap();
            CreateMap<SetMainStoryImageRequestCommand, StoryImage>().ReverseMap();

            CreateMap<StoryImage, StoryImageDto>().ReverseMap();

            CreateMap<Story, StoryDto>()
                .ReverseMap()
                .ForMember(
                    dest => dest.StoryImageUrl,
                    opt => opt.MapFrom(src => src.StoryImages.LastOrDefault().Url)
                )
                .ForMember(dest => dest.StoryImages, opt => opt.MapFrom(src => src.StoryImages));
        }
    }
}
