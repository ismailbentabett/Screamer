using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
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
            .Include(p => p.Covers)
            .Include(p => p.Adress)
            .Include(p => p.Socials)
            .SingleOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<PagedList<ApplicationUser>> GetUsersAsync(UserParams userParams)
    {
        var query = _context.Users.AsQueryable();

        query = userParams.OrderBy switch
        {
            "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
            _ => query.OrderByDescending(u => u.CreatedAt)
        };

        return await PagedList<ApplicationUser>.CreateAsync(
            query,
            userParams.PageNumber,
            userParams.PageSize
        );
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
            .Include(p => p.Covers)
            .Include(p => p.Adress)
            .Include(p => p.Socials)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    //get all async
    public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
    {
        return await _context.Users
            .Include(p => p.Avatars)
            .Include(p => p.Covers)
            .Include(p => p.Adress)
            .Include(p => p.Socials)
            .ToListAsync();
    }

    async Task<ApplicationUser> IUserRepository.GetUserByUsername(string username)
    {
        return await _context.Users
            .Include(p => p.Avatars)
            .Include(p => p.Covers)
            .Include(p => p.Adress)
            .Include(p => p.Socials)
            .SingleOrDefaultAsync(x => x.UserName == username);
    }

    Task<ApplicationUser> IUserRepository.GetUserByEmail(string email)
    {
        return _context.Users
            .Include(p => p.Avatars)
            .Include(p => p.Covers)
            .Include(p => p.Adress)
            .Include(p => p.Socials)
            .SingleOrDefaultAsync(x => x.Email == email);
    }

    async Task<ApplicationUser> IUserRepository.GetTheTopPreformingUser()
    {
        return await _context.Users
            .Include(p => p.Covers)
            .Include(p => p.Avatars)
            .Include(p => p.Adress)
            .Include(p => p.Socials)
            .OrderByDescending(x => x.Posts.Count())
            .FirstOrDefaultAsync();
    }

    async Task<PagedList<ApplicationUser>> IUserRepository.GetTheTopPreformingUsers(
        UserParams userParams
    )
    {
        var query = _context.Users
            .Include(p => p.Avatars)
            .Include(p => p.Covers)
            .Include(p => p.Adress)
            .Include(p => p.Socials)
            .OrderByDescending(x => x.Posts.Count())
            .AsQueryable();

        query = userParams.OrderBy switch
        {
            "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
            _ => query.OrderByDescending(u => u.CreatedAt)
        };

        return await PagedList<ApplicationUser>.CreateAsync(
            query,
            userParams.PageNumber,
            userParams.PageSize
        );
    }
}
