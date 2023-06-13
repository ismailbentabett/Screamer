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
                .ForMember(dest => dest.PostImages, opt => opt.MapFrom(src => src.PostImages))
                .ForMember(
                    dest => dest.PostCategories,
                    opt => opt.MapFrom(src => src.PostCategories)
                )
                .ForMember(dest => dest.PostHashtags, opt => opt.MapFrom(src => src.PostHashtags))
                .ForMember(dest => dest.Mood, opt => opt.MapFrom(src => src.Mood));
            CreateMap<PostCategory, PostCategoryDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<PostHashtag, PostHashtagDto>();
            CreateMap<Hashtag, HashtagDto>();

            CreateMap<Post, PostSearchResult>()
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

            CreateMap<Tag, UserTagDto>().ReverseMap();
            CreateMap<Tag, PostTagDto>().ReverseMap();
            CreateMap<PostMention, UserMentionDto>().ReverseMap();
            CreateMap<CommentMention, UserMentionDto>().ReverseMap();
            CreateMap<PostMention, PostMentionDto>().ReverseMap();
            CreateMap<CommentMention, CommentMentionDto>().ReverseMap();
            CreateMap<Mood, MoodDto>().ReverseMap();

            CreateMap<PostInputDto, PostDto>().ReverseMap();
            CreateMap<PostInputDto, Post>().ReverseMap();
            CreateMap<Post, UpdatePostRequestCommand>().ReverseMap();
            CreateMap<PostInputDto, UpdatePostRequestCommand>().ReverseMap();
        }
    }
}
