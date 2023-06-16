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

        public Task<BookMark> GetBookmarkByUserIdAndPostId(string UserId, int PostId)
        {
            var userBookmark = _context.BookMarks.FirstOrDefaultAsync(
                b => b.UserId == UserId && b.PostId == PostId
            );

            return userBookmark;
        }

        public async Task<PagedList<Post>> GetBookMarkedPosts(PostParams postParams)
        {
            var bookmark = _context.BookMarks.Where(b => b.UserId == postParams.UserId);

            var query = _context.Posts
                .Where(b => b.BookMarks.Any(b => b.UserId == postParams.UserId))
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

            return await PagedList<Post>.CreateAsync(
                query,
                postParams.PageNumber,
                postParams.PageSize
            );
        }
    }
}
