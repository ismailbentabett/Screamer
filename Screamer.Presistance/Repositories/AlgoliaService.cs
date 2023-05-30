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
        public async Task AddAllPostsToIndex(string indexName, IEnumerable<Post> posts)
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
                            createdAt = post.CreatedAt,
                            updatedAt = post.UpdatedAt
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
                AttributesToRetrieve = new[] { "ObjectID", "title","content", "createdAt", "updatedAt" },
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
