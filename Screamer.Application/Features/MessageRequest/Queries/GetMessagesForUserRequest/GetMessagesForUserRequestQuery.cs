using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Presistance;

namespace Screamer.Application.Features.MessageRequest;
    public record GetMessagesForUserRequestQuery : IRequest<List<MessageDto>>{
        public string userId{
            get;
            set;
        }

        public MessageParams messageParams {
            get;
            set;
        }
    }
