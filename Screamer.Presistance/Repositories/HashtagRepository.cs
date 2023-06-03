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
    public class HashtagRepository : GenericRepository<Hashtag>, IHashtagRepository
    {
        public HashtagRepository(ScreamerDbContext context)
            : base(context) { }

        async Task<Hashtag> IHashtagRepository.GetHashTagByNameAsync(string name)
        {
            return await _context.Hashtags.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}
