using Algolia.Search.Clients;
using Algolia.Search.Models.Search;
using Newtonsoft.Json;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Presistance.Repositories
{
    public class AlgoliaService : IAlgoliaService
    {
        private readonly SearchClient _algoliaClient;
        private readonly IUnitOfWork _uow;

        public AlgoliaService(SearchClient algoliaClient, IUnitOfWork uow)
        {
            _algoliaClient = algoliaClient;
            _uow = uow;
        }

        //add all to index
        public async Task AddAllPostsToIndex(string indexName, IEnumerable<PostSearchResult> posts)
        {
            // Add or update index in Algolia
            var index = _algoliaClient.InitIndex(indexName);
            await index.SaveObjectsAsync(
                posts.Select(
                    post =>
                        new
                        {
                            ObjectID = post.Id.ToString(),
                            title = post.Title,
                            content = post.Content,
                            imageUrl = post.ImageUrl,
                            userId = post.UserId,
                            views = post.Views,
                            PostImages = post.PostImages,
                            postImageUrl = post.PostImageUrl,
                            createdAt = post.CreatedAt,
                            updatedAt = post.UpdatedAt
                        }
                )
            );
        }

        public async Task AddAllUsersToIndex(string indexName, IEnumerable<UserSearchResult> users)
        {
            // Add or update index in Algolia
            var index = _algoliaClient.InitIndex(indexName);
            await index.SaveObjectsAsync(
                users.Select(
                    user =>
                        new
                        {
                            ObjectID = user.Id.ToString(),
                            email = user.Email,
                            bio = user.Bio,
                            website = user.Website,
                            birthday = user.Birthday,
                            gender = user.Gender,
                            phone = user.Phone,
                            firstName = user.FirstName,
                            lastName = user.LastName,
                            userName = user.userName,
                            avatarUrl = user.AvatarUrl,
                            coverUrl = user.CoverUrl,
                            socials = user.Socials,
                            adress = user.Adress,
                            createdAt = user.CreatedAt,
                            updatedAt = user.UpdatedAt,
                            avatars = user.Avatars,
                        }
                )
            );
        }

        public async Task<IEnumerable<SearchResult>> Search(string indexName, string query)
        {
            var index = _algoliaClient.InitIndex(indexName);

            var searchOptions = new Query
            {
                SearchQuery = query,
                AttributesToRetrieve = new[]
                {
                    "ObjectID",
                    "title",
                    "content",
                    "createdAt",
                    "updatedAt"
                },
                AttributesToHighlight = new[] { "title" },
                HitsPerPage = 10
            };

            var searchResponse = await index.SearchAsync<dynamic>(searchOptions);

            var searchResults = searchResponse.Hits.Select(
                hit =>
                    new SearchResult
                    {
                        ObjectID = hit.Id,
                        Title = hit.title,
                        Name = hit.content,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    }
            );

            return searchResults;
        }
    }
}
