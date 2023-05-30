using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algolia.Search.Clients;
using Algolia.Search.Models.Search;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IAlgoliaService
    {
        Task<IEnumerable<SearchResult>> Search(string indexName, string query);
        Task AddAllPostsToIndex(string indexName, IEnumerable<Post> posts);
    }

}
