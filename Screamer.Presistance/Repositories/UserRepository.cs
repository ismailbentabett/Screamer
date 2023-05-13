
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Identity.Models;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance;

public class UserRepository : IUserRepository
{
    private readonly ScreamerDbContext _context;
    private readonly IMapper _mapper;


    public UserRepository(ScreamerDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }






    public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(p => p.Avatars)
           .SingleOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
    {
        return await _context.Users
             .Include(p => p.Avatars)
           .ToListAsync();
    }

    public async Task<ApplicationUser> Update(ApplicationUser user)
    {
        return await Task.FromResult(_context.Users.Update(user).Entity);
    }
    public async Task<ApplicationUser> Delete(ApplicationUser user)
    {
        return await Task.FromResult(_context.Users.Remove(user).Entity);
    }

    async Task<ApplicationUser> IUserRepository.GetUserByIdAsync(string id)
    {
        return await _context.Users
                    .Include(p => p.Avatars)
                    .SingleOrDefaultAsync(x => x.Id == id);
    }
}
