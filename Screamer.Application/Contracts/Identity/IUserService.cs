using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List <User>> GetAllUsers();
        Task<User> GetUsers(int UserId);

    }
}