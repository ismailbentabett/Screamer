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
            var query = _context.Posts
                .Where(u => u.Id == id)
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

            query = postParams.OrderBy switch
            {
                "CreatedAt" => query.OrderByDescending(u => u.CreatedAt),
                _ => query.OrderByDescending(u => u.CreatedAt)
            };
            return PagedList<Post>.CreateAsync(query, postParams.PageNumber, postParams.PageSize);
        }

        public Task<PagedList<Post>> GetRecommendedPosts(PostParams postParams)
        {
            var randomPosts = _context.Posts
                .OrderBy(u => Guid.NewGuid())
                .Include(u => u.PostImages)
                .Include(u => u.PostCategories)
                .ThenInclude(pc => pc.Category)
                .Include(u => u.PostHashtags)
                .ThenInclude(pc => pc.Hashtag)
                .Include(pc => pc.Tags)
                .ThenInclude(pc => pc.User)
                .Include(u => u.Mentions)
                .ThenInclude(pc => pc.User)
                .Include(u => u.Mood);

            return PagedList<Post>.CreateAsync(
                randomPosts.AsQueryable(),
                postParams.PageNumber,
                postParams.PageSize
            );
        }

        async Task<IEnumerable<Post>> IPostRepository.GetAllPosts()
        {
            var query = _context.Posts;

            return await query.ToListAsync();
        }

        /*        public new async Task AddAsync(Post post ,
                       
               )
       {
           await _context.Posts.AddAsync(post);
           await _context.SaveChangesAsync();
       } */

        //most used hashtags
        async Task<IEnumerable<PostHashtag>> IPostRepository.GetMostUsedHashtags()
        {
            var postHashtags = _context.PostHashtags
                .GroupBy(p => p.HashtagId)
                .Select(g => new { HashtagId = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .Join(
                    _context.Hashtags,
                    ph => ph.HashtagId,
                    h => h.Id,
                    (ph, h) => new PostHashtag { Hashtag = h, HashtagId = ph.HashtagId, }
                );

            var commentHashtags = _context.CommentHashtags
                .GroupBy(p => p.HashtagId)
                .Select(g => new { HashtagId = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .Join(
                    _context.Hashtags,
                    ph => ph.HashtagId,
                    h => h.Id,
                    (ph, h) => new PostHashtag { Hashtag = h, HashtagId = ph.HashtagId, }
                );
            var allHashtags = postHashtags.Union(commentHashtags);
            return await allHashtags.ToListAsync();
        }

        async Task<IEnumerable<PostCategory>> IPostRepository.GetMostUsedCategories()
        {
            var postCategories = _context.PostCategories
                .GroupBy(p => p.CategoryId)
                .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Take(10)
                .Join(
                    _context.Categories,
                    ph => ph.CategoryId,
                    h => h.Id,
                    (ph, h) => new PostCategory { Category = h, CategoryId = ph.CategoryId, }
                );

            return await postCategories.ToListAsync();
        }

        async Task<Post> IPostRepository.GetTheTopPreformingPost()
        {
            //GetTheTopPreformingPost
            return await _context.Posts
                .Include(pc => pc.User)
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
                .OrderByDescending(p => p.Reactions.Count + p.Comments.Count)
                .FirstOrDefaultAsync();
        }

        async Task<PagedList<Post>> IPostRepository.GetTheTopPreformingPosts(PostParams postParams)
        {
            var query = _context.Posts
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
                .OrderByDescending(p => p.Reactions.Count + p.Comments.Count)
                .AsQueryable();

            return await PagedList<Post>.CreateAsync(
                query,
                postParams.PageNumber,
                postParams.PageSize
            );
        }

        async Task<PagedList<Post>> IPostRepository.GetPostsByHashTag(PostParams postParams)
        {
            var query = _context.Posts
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
                .Where(p => p.PostHashtags.Any(ph => ph.Hashtag.Name == postParams.hashtagName))
                .AsQueryable();

            return await PagedList<Post>.CreateAsync(
                query,
                postParams.PageNumber,
                postParams.PageSize
            );
        }

        async Task<PagedList<Post>> IPostRepository.GetPostsByCategory(PostParams postParams)
        {
            var query = _context.Posts
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
                .Where(p => p.PostCategories.Any(ph => ph.Category.Name == postParams.category))
                .AsQueryable();

            return await PagedList<Post>.CreateAsync(
                query,
                postParams.PageNumber,
                postParams.PageSize
            );
        }

        async Task<PagedList<Post>> IPostRepository.GetTrendingPosts(PostParams postParams)
        {
            var query = _context.Posts
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
                .Where(p => p.CreatedAt >= DateTime.Now.AddDays(-7))
                .OrderByDescending(p => p.Reactions.Count + p.Comments.Count)
                .AsQueryable();

            return await PagedList<Post>.CreateAsync(
                query,
                postParams.PageNumber,
                postParams.PageSize
            );
        }
    }
}
