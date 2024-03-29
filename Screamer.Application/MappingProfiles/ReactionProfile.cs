using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest;
using Screamer.Application.Features.ReactionRequest.Commands.RemoveReactionRequest;
using Screamer.Application.Features.ReactionRequest.Commands.UpdateReactionRequest;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class ReactionProfile : Profile
    {
        public ReactionProfile()
        {
            CreateMap<PostReaction, PostReactionDto>().ReverseMap();
            CreateMap<CommentReaction, CommentReactionDto>().ReverseMap();

            CreateMap<CommentReaction, AddPostReactionRequestCommand>().ReverseMap();
            CreateMap<CommentReaction, AddCommentReactionRequestCommand>().ReverseMap();

            CreateMap<PostReaction, UpdateReactionRequestCommand>().ReverseMap();
            CreateMap<CommentReaction, RemoveReactionRequestCommand>().ReverseMap();
            CreateMap<PostReaction, UpdateReactionRequestCommand>().ReverseMap();
            CreateMap<CommentReaction, RemoveReactionRequestCommand>().ReverseMap();
        }
    }
}
