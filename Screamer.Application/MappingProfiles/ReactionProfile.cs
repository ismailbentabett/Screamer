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
            CreateMap<PostReaction, ReactionDto>().ReverseMap();
            CreateMap<CommentReaction, ReactionDto>().ReverseMap();

            CreateMap<PostReaction, AddReactionRequestCommand>().ReverseMap();
            CreateMap<CommentReaction, AddReactionRequestCommand>().ReverseMap();
            CreateMap<PostReaction, UpdateReactionRequestCommand>().ReverseMap();
            CreateMap<CommentReaction, RemoveReactionRequestCommand>().ReverseMap();
            CreateMap<PostReaction, UpdateReactionRequestCommand>().ReverseMap();
            CreateMap<CommentReaction, RemoveReactionRequestCommand>().ReverseMap();
        }
    }
}
