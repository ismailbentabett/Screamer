using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.MessageRequest
{
    public record DeleteMessageRequestCommand :
    IRequest<
        int
    >
    {
      public string userId{
        get;
        set;
      }
      public int messageId{
        get;
        set;
      }
    }
}