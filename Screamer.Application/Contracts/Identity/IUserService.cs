using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Application.Contracts.Identity
{
    public interface IUserService
    {
       
        Task<List<User>> GetUsers();
        Task<User> GetUser(string userId);
        public string UserId { get; }

    }
}