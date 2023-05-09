using Screamer.Application.Models.Identity;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Screamer.Application.Contracts.Identity;
using Screamer.Domain.Common;
using System.Security.Claims;

namespace Screamer.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }


        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<ApplicationUser> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new ApplicationUser
            {
                Email = user.Email,
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var users = await _userManager.GetUsersInRoleAsync("user");
            return users.Select(q => new ApplicationUser
            {
                Id = q.Id,
                Email = q.Email,
                FirstName = q.FirstName,
                LastName = q.LastName
            }).ToList();
        }
    }
}
