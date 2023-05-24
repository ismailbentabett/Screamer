using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Helpers;
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



        public async Task<PagedList<Post>> GetPostsByUserId(string userId, PostParams postParams
)
        {
            var query = _context.Posts
            .AsQueryable();

            query = query.Where(u => u.UserId == userId)
            .Include(u => u.PostImages);

            query = postParams.OrderBy switch
            {
                "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
                _ => query.OrderByDescending(u => u.CreatedAt)
            };

            return await PagedList<Post>.CreateAsync(query, postParams.PageNumber, postParams.PageSize);
        }



        public async Task<PagedList<Post>> GetAllAsync(
            PostParams postParams
        )
        {
            var query = _context.Posts.AsQueryable();

            query = postParams.OrderBy switch
            {
                "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
                _ => query.OrderByDescending(u => u.CreatedAt)
            };

            return await PagedList<Post>.CreateAsync(query, postParams.PageNumber, postParams.PageSize);



        }


    }
}