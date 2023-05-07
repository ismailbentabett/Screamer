using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Models.Email;

namespace Screamer.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmail (EmailMessage email);
    }
}