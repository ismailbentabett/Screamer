using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class StoryRepository : GenericRepository<Story>, IStoryRepository
    {
        public StoryRepository(ScreamerDbContext context)
            : base(context) { }

        public async Task<Story> GetStoryByIdAsync(int id)
        {
            return await _context.Storys.FindAsync(id);
        }

        public async Task<List<Story>> GetAllStoriesAsync()
        {
            var currentTimeMinus24Hours = DateTime.UtcNow.AddHours(-24);

            return await _context.Storys
                .Include(story => story.StoryImages)
                .Include(c => c.User)
                .ThenInclude(c => c.Avatars)
                .Where(story => story.CreatedAt >= currentTimeMinus24Hours)
                .ToListAsync();
        }

        public async Task<List<Story>> GetStoriesByFollowingAsync(string userId)
        {
            var currentTimeMinus24Hours = DateTime.UtcNow.AddHours(-24);

            var follows = _context.Follows.AsQueryable();

            follows = follows.Where(follow => follow.SourceUserId == userId);

           var  users = follows.Select(follow => follow.TargetUser);

            return await _context.Storys
                .Include(story => story.StoryImages)
                .Include(c => c.User)
                .ThenInclude(c => c.Avatars)
                .Where(
                    story =>
                        users.Any(u => u.Id == story.UserId)
                        || story.UserId == userId
                        && story.CreatedAt >= currentTimeMinus24Hours
                )
                .ToListAsync();
        }
    }
}
