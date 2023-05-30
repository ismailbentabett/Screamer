using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Screamer.WebApi.Controllers
{
    public class SearchController
    {
        private readonly IUnitOfWork _uow;
        private readonly IAlgoliaService _algoliaService;

        public SearchController(IUnitOfWork uow, IAlgoliaService algoliaService)
        {
            _uow = uow;
            _algoliaService = algoliaService;
        }

        //search for users
        /*         public async Task<IEnumerable<SearchResult>> SearchUsers(string query)
                {
                    var users = await _uow.UserRepository.GetUsersAsync();
                    var searchResults = new List<SearchResult>();
                    foreach (var user in users)
                    {
                        searchResults.Add(new SearchResult
                        {
                            Id = user.Id,
                            Name = user.UserName,
                            CreatedAt = user.CreatedAt,
                            UpdatedAt = user.UpdatedAt
                        });
                    }
        
                    return searchResults;
                } */

        //search for posts

        [HttpGet("posts/{query}")]
        public async Task<IEnumerable<SearchResult>> SearchPosts(string query)
        {
            var posts = await _uow.PostRepository.GetAllAsync();
            await _algoliaService.AddAllPostsToIndex("post", posts);

            var searchResults = await _algoliaService.Search("post", query);
            return searchResults;
        }
    }
}
