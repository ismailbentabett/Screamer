using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
