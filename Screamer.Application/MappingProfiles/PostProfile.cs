using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
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
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<PostInputDto, Post>().ReverseMap();
            CreateMap<GetAllPostsRequestQuery, PostDto>().ReverseMap();

                    //cre
CreateMap<CreatePostRequestCommand, Post>().ReverseMap();
CreateMap<UpdatePostRequestCommand, Post>().ReverseMap();


        }
    }
}