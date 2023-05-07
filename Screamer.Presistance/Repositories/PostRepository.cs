using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        /*         Task<IEnumerable<Post>> GetPostsByUserId(int userId);
 */
        public PostRepository(ScreamerDbContext context) : base(context)
        {
        }



        public async Task<IEnumerable<Post>> GetPostsByUserId(int userId)
        {
            return await _context.Posts.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
        }
    }
}