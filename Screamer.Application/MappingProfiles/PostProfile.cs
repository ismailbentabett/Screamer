using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Application.Features.postImageRequest.Commands;
using Screamer.Application.Features.PostRequest.Commands.CreatePostRequest;
using Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest;
using Screamer.Application.Features.PostRequest.Queries.GetAllPostsRequest;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<Post, PostDto>()
                .ReverseMap()
                .ForMember(
                    dest => dest.PostImageUrl,
                    opt => opt.MapFrom(src => src.PostImages.LastOrDefault().Url)
                )
                .ForMember(dest => dest.PostImages, opt => opt.MapFrom(src => src.PostImages));
            CreateMap<PostInputDto, Post>().ReverseMap();
            CreateMap<GetAllPostsRequestQuery, PostDto>().ReverseMap();

            //cre
            CreateMap<CreatePostRequestCommand, Post>()
                .ReverseMap();
            CreateMap<CreatePostRequestCommand, Post>().ReverseMap();
            CreateMap<AddPostImageRequestCommand, PostImage>().ReverseMap();
            CreateMap<DeletePostImageRequestCommand, PostImage>().ReverseMap();
            CreateMap<SetMainPostImageRequestCommand, PostImage>().ReverseMap();

            CreateMap<PostImage, PostImageDto>().ReverseMap();
        }
    }
}
