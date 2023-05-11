using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Screamer.Application.Features.PostRequest.Commands.UpdateUserRequest;

namespace Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest
{
    public class UpdateUserRequestCommandValidator : AbstractValidator
    <
        UpdateUserRequestCommand
        >
    {
        public UpdateUserRequestCommandValidator()
        {
            

        }
    }
}