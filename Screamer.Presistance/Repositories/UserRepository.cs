
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

    public void Update(ApplicationUser user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }
    public void Delete(ApplicationUser user)
    {
        _context.Users.Remove(user);
    }

    async Task<ApplicationUser> IUserRepository.GetUserByIdAsync(string id)
    {
        return await _context.Users.FindAsync(id);
    }
}
