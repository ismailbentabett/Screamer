using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        /*         Task<IEnumerable<Post>> GetPostsByUserId(int userId);
 */
        public PostRepository(ScreamerDbContext context)
            : base(context) { }

        public async Task<PagedList<Post>> GetPostsByUserId(string userId, PostParams postParams)
        {
            var query = _context.Posts
                .Where(u => u.UserId == userId)
                .Include(u => u.PostImages)
                .Include(u => u.Comments)
                .Include(u => u.Reactions)
                .Include(u => u.PostCategories)
                .Include(u => u.User)
                .AsQueryable();

            query = postParams.OrderBy switch
            {
                "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
                _ => query.OrderByDescending(u => u.CreatedAt)
            };

            return await PagedList<Post>.CreateAsync(
                query,
                postParams.PageNumber,
                postParams.PageSize
            );
        }

        //get post by id
        public async Task<Post> GetPostById(int id)
        {
            var query = _context.Posts.Where(u => u.Id == id).Include(u => u.PostImages);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PagedList<Post>> GetAllAsync(PostParams postParams)
        {
            var query = _context.Posts.AsQueryable();

            query = postParams.OrderBy switch
            {
                "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
                _ => query.OrderByDescending(u => u.CreatedAt)
            };

            return await PagedList<Post>.CreateAsync(
                query,
                postParams.PageNumber,
                postParams.PageSize
            );
        }

        async Task<List<PostImage>> IPostRepository.GetPostImageByPostIdAsync(int postId)
        {
            // Get post by ID and include its post images
            var query = _context.Posts.Where(p => p.Id == postId).Include(p => p.PostImages);

            // Retrieve the post and its associated post images
            var post = await query.FirstOrDefaultAsync();

            // Return only the post images
            return post?.PostImages.ToList();
        }

        public Task<PagedList<Post>> GetPostsByFollowing(
            string userId,
            RecommendationParams recommendationParams
        )
        {
            var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
            var follows = _context.Follows.AsQueryable();

            follows = follows.Where(follow => follow.SourceUserId == recommendationParams.UserId);
            users = follows.Select(follow => follow.TargetUser);

            var posts = _context.Posts
                .Where(p => users.Any(u => u.Id == p.UserId))
                .Include(p => p.PostImages)
                .Include(p => p.User)
                .AsQueryable();

            return PagedList<Post>.CreateAsync(
                posts,
                recommendationParams.PageNumber,
                recommendationParams.PageSize
            );
        }

        public Task<PagedList<Post>> GetMostRecentPosts(PostParams postParams)
        {
            var query = _context.Posts
                .Include(u => u.PostImages)
                .Include(u => u.Comments)
                .Include(u => u.Reactions)
                .Include(u => u.PostCategories)
                .Include(u => u.User)
                .AsQueryable();

            query = postParams.OrderBy switch
            {
                "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
                _ => query.OrderByDescending(u => u.CreatedAt)
            };
            return PagedList<Post>.CreateAsync(query, postParams.PageNumber, postParams.PageSize);
        }

        public Task<PagedList<Post>> GetRecommendedPosts(PostParams postParams)
        {
            var randomPosts = _context.Posts.OrderBy(r => Guid.NewGuid()).Take(10).ToList();

            return PagedList<Post>.CreateAsync(
                randomPosts.AsQueryable(),
                postParams.PageNumber,
                postParams.PageSize
            );
        }
    }
}
