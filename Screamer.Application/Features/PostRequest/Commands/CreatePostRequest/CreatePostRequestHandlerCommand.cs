using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;
        private readonly IAlgoliaService _algoliaService;

        public CreatePostRequestHandlerCommand(
            IPostRepository postRepository,
            IMapper mapper,
            IUnitOfWork uow,
            IAlgoliaService algoliaService
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _uow = uow;
            _algoliaService = algoliaService;
        }

        public async Task<int> Handle(
            CreatePostRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            /*       var validator = new CreatePostRequestCommandValidator();
                  var validationResult = await validator.ValidateAsync(request);
                  if (validationResult.IsValid)
                  {
                      throw new BadRequestException
                      (
                          $"Command validation errors for type {typeof(CreatePostRequestCommand).Name}",
                          validationResult.Errors
                      );
                  } */

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
                    // Handle the case when the category doesn't exist and throw an exception or return an error response
                    throw new Exception($"Category '{categoryName}' does not exist.");
                }

                var postCategory = new PostCategory
                {
                    CategoryId = category.Id,
                    Category = category,
                    PostId = post.Id,
                    Post = post
                };

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
                var postHashtag = new PostHashtag
                {
                    HashtagId = hashtag.Id,
                    Hashtag = hashtag,
                    PostId = post.Id,
                    Post = post
                };
                post.PostHashtags.Add(postHashtag);
                hashtag.PostHashtags.Add(postHashtag);
            }

            var mood = await _uow.MoodRepository.AddAsync(new Mood { MoodType = request.MoodType });
            post.Mood = mood;
            await _postRepository.AddAsync(post);

            var posts = await _uow.PostRepository.GetAllAsync();
            //map post to PostSearchDto
            var postSearchDto = _mapper.Map<IEnumerable<PostSearchResult>>(posts);

            await _algoliaService.AddAllPostsToIndex("post", postSearchDto);

            //get post by id
            var postById = await _uow.PostRepository.GetPostById(post.Id);
            foreach (var tag in request.TagsArr)
            {
                var userMention = await _uow.UserRepository.GetUserByUsernameAsync(tag);

                if (userMention == null)
                {
                    // Handle the case when the category doesn't exist and throw an exception or return an error response
                    throw new Exception($"User '{tag}' does not exist.");
                }
                var postTag = new Tag
                {
                    UserId = userMention.Id,
                    User = userMention,
                    PostId = postById.Id,
                    Post = postById
                };
                postById.Tags.Add(postTag);
                userMention.Tags.Add(postTag);
            }

            foreach (var mention in request.MentionsArr)
            {
                var userMention = await _uow.UserRepository.GetUserByUsernameAsync(mention);

                if (userMention == null)
                {
                    // Handle the case when the category doesn't exist and throw an exception or return an error response
                    throw new Exception($"User '{mention}' does not exist.");
                }
                var postMention = new Mention
                {
                    UserId = userMention.Id,
                    User = userMention,
                    PostId = postById.Id,
                    Post = postById
                };
                postById.Mentions.Add(postMention);
                userMention.Mentions.Add(postMention);
            }
                        await _uow.Complete();

            return post.Id;
        }
    }
}
