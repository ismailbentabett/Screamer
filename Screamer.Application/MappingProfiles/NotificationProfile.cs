using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Dtos;
using Screamer.Application.Features.NotificationRequest.Commands.CreateNotificationRequest;
using Screamer.Application.Features.NotificationRequest.Commands.DeleteNotificationRequest;
using Screamer.Application.Features.NotificationRequest.Commands.UpdateNotificationRequest;
using Screamer.Domain.Entities;

namespace Screamer.Application.MappingProfiles
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationRequestCommand>().ReverseMap();
            CreateMap<NotificationDto, CreateNotificationRequestCommand>().ReverseMap();
            CreateMap<Notification, UpdateNotificationRequestCommand>().ReverseMap();
            CreateMap<NotificationDto, UpdateNotificationRequestCommand>().ReverseMap();
            CreateMap<Notification, DeleteNotificationRequestCommand>().ReverseMap();
            CreateMap<NotificationDto, DeleteNotificationRequestCommand>().ReverseMap();
        }
    }
}
