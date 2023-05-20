using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.MessageRequest
{
    public record CreateMessageRequestCommand :
    IRequest<
        MessageDto
    >
    {
      public CreateMessageDto createMessageDto
        {
            get;
            set;
        }
        public string userId 
        {
            get;
            set;
        }
    }
}