using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.PostRequest.Commands.CreatePostRequest
{
    public class CreatePostRequestHandlerCommand : IRequestHandler<CreatePostRequestCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;
        private readonly IAlgoliaService _algoliaService;

        public CreatePostRequestHandlerCommand(
            IMapper mapper,
            IUnitOfWork uow,
            IAlgoliaService algoliaService
        )
        {
            _mapper = mapper;
            _uow = uow;
            _algoliaService = algoliaService;
        }

        public async Task<int> Handle(
            CreatePostRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.UserId);

            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.UserId);

            var post = _mapper.Map<CreatePostRequestCommand, Post>(request);
            post.User = user;
            foreach (var categoryName in request.Categories)
            {
                var category = await _uow.CategoryRepository.GetCategoryByNameAsync(categoryName);
                if (category == null)
                {
                    throw new Exception($"Category '{categoryName}' does not exist.");
                }

                var postCategory = new PostCategory { Category = category, Post = post };

                post.PostCategories.Add(postCategory);
                category.PostCategories.Add(postCategory);
            }
            foreach (var hashTagName in request.Hashtags)
            {
                var hashtag = await _uow.HashtagRepository.GetHashTagByNameAsync(hashTagName);
                if (hashtag == null)
                {
                    hashtag = new Hashtag { Name = hashTagName };
                }
                var postHashtag = new PostHashtag { Hashtag = hashtag, Post = post };
                post.PostHashtags.Add(postHashtag);
                hashtag.PostHashtags.Add(postHashtag);
            }
            if (request.TagsArr != null)
            {
                foreach (var tag in request.TagsArr)
                {
                    var userMention = await _uow.UserRepository.GetUserByUsernameAsync(tag);

                    if (userMention == null)
                    {
                        throw new Exception($"User '{tag}' does not exist.");
                    }
                    var postTag = new Tag { User = userMention, Post = post };
                    post.Tags.Add(postTag);
                    userMention.Tags.Add(postTag);
                }
            }
            if (request.MentionsArr != null)
            {
                foreach (var mention in request.MentionsArr)
                {
                    var userMention = await _uow.UserRepository.GetUserByUsernameAsync(mention);

                    if (userMention == null)
                    {
                        throw new Exception($"User '{mention}' does not exist.");
                    }
                    var postMention = new PostMention
                    {
                        User = userMention,
                        Post = post,
                    };
                    post.Mentions.Add(postMention);
                    userMention.PostMentions.Add(postMention);
                }
            }

            var mood = new Mood { MoodType = request.MoodType };
            post.Mood = mood;

            await _uow.PostRepository.AddAsync(post);

            await _uow.Complete();
            var posts = await _uow.PostRepository.GetAllAsync();
            var postSearchDto = _mapper.Map<IEnumerable<PostSearchResult>>(posts);

            await _algoliaService.AddAllPostsToIndex("post", postSearchDto);

            return post.Id;

            throw new Exception("Problem saving changes");
        }
    }
}
