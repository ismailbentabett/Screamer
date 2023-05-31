using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Dtos;
using AutoMapper;

namespace Screamer.WebApi.Controllers
{
    public class SearchController
    {
        private readonly IUnitOfWork _uow;
        private readonly IAlgoliaService _algoliaService;
        private readonly IMapper _mapper;

        public SearchController(IUnitOfWork uow, IAlgoliaService algoliaService, IMapper mapper)
        {
            _uow = uow;
            _algoliaService = algoliaService;
            _mapper = mapper;
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

        [HttpGet("posts")]
        public async Task<IEnumerable<PostSearchResult>> SearchPosts()
        {
            var posts = await _uow.PostRepository.GetAllAsync();

            var postSearchDto = _mapper.Map<IEnumerable<PostSearchResult>>(posts);

            await _algoliaService.AddAllPostsToIndex("post", postSearchDto);

            return postSearchDto;
        }

        [HttpGet("users")]
        public async Task<IEnumerable<UserSearchResult>> SearchUsers()
        {
            var searchusers = await _uow.UserRepository.GetAllAsync();
            var userSearchDto = _mapper.Map<IEnumerable<UserSearchResult>>(searchusers);
            await _algoliaService.AddAllUsersToIndex("user", userSearchDto);

            return userSearchDto;
        }
    }
}
