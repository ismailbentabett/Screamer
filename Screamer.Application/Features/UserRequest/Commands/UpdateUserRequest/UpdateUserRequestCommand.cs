using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Screamer.Application.Dtos;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.PostRequest.Commands.UpdateUserRequest
{
    public class UpdateUserRequestCommand
: IRequest<Unit>
    {
        public string Id { get; set; }

        public string Bio { get; set; }
        public string Website { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string userName { get; set; }

        public SocialDto Socials { get; set; }
        public AdressDto Adress { get; set; }


    }
}