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
            return await _context.Storys
                .Include(story => story.StoryImages)
                .Include(c => c.User)
                .ThenInclude(c => c.Avatars)
                .ToListAsync();
        }

        public async Task<List<Story>> GetStoriesByFollowingAsync(string userId)
        {
            //get user by id
            var user = await _context.Users
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return await _context.Storys
                .Include(story => story.StoryImages)
                .Where(
                    story => user.Following.Any(following => following.SourceUserId == story.UserId)
                )
                .ToListAsync();
        }
    }
}
