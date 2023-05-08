using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Identity;
using Screamer.Identity.Models;

namespace Screamer.Application.Contracts.Identity
{
    public interface IUserService
    {
       
        Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUser(string userId);
        public string UserId { get; }

    }
}