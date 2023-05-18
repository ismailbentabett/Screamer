using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Domain;
using Screamer.Identity.Models;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        
 private readonly ScreamerDbContext _context;
        public FollowRepository(ScreamerDbContext context, AutoMapper.IMapper _mapper)
        {
            _context = context;
        }

        public async Task<Follow> GetUserFollow(string sourceUserId, string targetUserId)
        {
             return await _context.Follows.FindAsync(sourceUserId, targetUserId);
        }

        public async Task<PagedList<FollowDto>> GetUserFollows(FollowParams followParams)
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            var follows = _context.Follows.AsQueryable();

            if (followParams.Predicate == "following")
            {
                follows = follows.Where(follow => follow.SourceUserId == followParams.UserId);
                users = follows.Select(follow => follow.TargetUser);
            }

            if (followParams.Predicate == "followers")
            {
                follows = follows.Where(follow => follow.TargetUserId == followParams.UserId);
                users = follows.Select(follow => follow.SourceUser);
            }

              var following = users.Select(user => new FollowDto
            {
                UserName = user.UserName,
               
                UserId = user.Id
            });

            return await PagedList<FollowDto>.CreateAsync(following, followParams.PageNumber, followParams.PageSize);
        }

        public async Task<ApplicationUser> GetUserWithFollows(string userId)
        {
            return await _context.Users
                .Include(x => x.Followers)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }

        Task<Follow> IGenericRepository<Follow>.AddAsync(Follow entity)
        {
            throw new NotImplementedException();
        }

        Task<Follow> IGenericRepository<Follow>.DeleteAsync(Follow entity)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<Follow>> IGenericRepository<Follow>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Follow> IGenericRepository<Follow>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

      

      

        Task<Follow> IGenericRepository<Follow>.UpdateAsync(Follow entity)
        {
            throw new NotImplementedException();
        }
    }
}