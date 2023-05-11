using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Identity.Models;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IUserRepository
    {
        void Update(ApplicationUser user);
        void Delete(ApplicationUser user);

         
        Task<IEnumerable<ApplicationUser>> GetUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByUsernameAsync(string username);
    }
}