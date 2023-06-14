using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Helpers;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class BookMarkRepository : GenericRepository<BookMark>, IBookMarkRepository
    {
        public BookMarkRepository(ScreamerDbContext context)
            : base(context) { }

        public Task<PagedList<Post>> GetAllBookmarksByUserIdRequest(PostParams postParams)
        {
            var userBookmarks = _context.BookMarks.Where(b => b.UserId == postParams.UserId);
            var posts = _context.Posts
                .Where(p => userBookmarks.Any(b => b.PostId == p.Id))
                .Include(u => u.PostImages)
                .Include(u => u.PostCategories)
                .ThenInclude(pc => pc.Category)
                .Include(u => u.PostHashtags)
                .ThenInclude(pc => pc.Hashtag)
                .Include(pc => pc.Tags)
                .ThenInclude(pc => pc.User)
                .Include(u => u.Mentions)
                .ThenInclude(pc => pc.User)
                .Include(u => u.Mood)
                .AsQueryable();

            return PagedList<Post>.CreateAsync(posts, postParams.PageNumber, postParams.PageSize);
        }
    }
}
