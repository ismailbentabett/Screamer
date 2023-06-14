using Screamer.Identity.Models;
using Screamer.Application.Helpers;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IUserRepository
    {
        Task<ApplicationUser> Update(ApplicationUser user);
        Task<ApplicationUser> Delete(ApplicationUser user);

        Task<PagedList<ApplicationUser>> GetUsersAsync(UserParams userParams);
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByUsernameAsync(string username);

        //get all async
        Task<IEnumerable<ApplicationUser>> GetAllAsync();

        Task<ApplicationUser> GetUserByUsername(string username);

        Task<ApplicationUser> GetUserByEmail(string email);

        Task<ApplicationUser> GetTheTopPreformingUser();
        Task<PagedList<ApplicationUser>> GetTheTopPreformingUsers(PostParams postParams);
    }
}
