using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class MessageProfile :  Profile
    {
        public MessageProfile(){
         CreateMap<Message, MessageDto>()
                .ForMember(d => d.SenderPhotoUrl, o => o.MapFrom(s => s.Sender.Avatars
                    .FirstOrDefault(x => x.IsMain).Url))
                .ForMember(d => d.RecipientPhotoUrl, o => o.MapFrom(s => s.Recipient.Avatars
                    .FirstOrDefault(x => x.IsMain).Url));


                CreateMap<
                ChatRoom,    
                ChatRoomDto>();
                CreateMap<
                ChatRoomUser,
                ChatRoomUserDto>();
                

        

    }
    }
}