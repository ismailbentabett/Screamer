using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<PagedList<Post>> GetPostsByUserId(string userId, PostParams postParams);
        Task<PagedList<Post>> GetAllAsync(PostParams postParams);
        Task<Post> GetPostById(int id);
        Task<List<PostImage>> GetPostImageByPostIdAsync(int postId);

        Task<PagedList<Post>> GetPostsByFollowing(
            string userId,
            RecommendationParams recommendationParams
        );
        Task<PagedList<Post>> GetMostRecentPosts(PostParams postParams);
        Task<PagedList<Post>> GetRecommendedPosts(PostParams postParams);

        public Task<IEnumerable<Post>> GetAllPosts();
        Task<IEnumerable<PostHashtag>> GetMostUsedHashtags();
        Task<IEnumerable<PostCategory>> GetMostUsedCategories();

        Task<Post> GetTheTopPreformingPost();
        Task<PagedList<Post>> GetTheTopPreformingPosts(PostParams postParams);
        Task<PagedList<Post>> GetPostsByHashTag(PostParams postParams);
        Task<PagedList<Post>> GetPostsByCategory(PostParams postParam);
        Task<PagedList<Post>> GetTrendingPosts(PostParams postParams);
    }
}
