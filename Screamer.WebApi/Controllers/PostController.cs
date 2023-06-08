using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Features.CommentRequest.Commands.AddCommentRequest;
using Screamer.Application.Features.CommentRequest.Commands.AddReplyRequest;
using Screamer.Application.Features.CommentRequest.Commands.DeleteCommentRequest;
using Screamer.Application.Features.CommentRequest.Commands.UpdateCommentRequest;
using Screamer.Application.Features.CommentRequest.Queries.GetCommentByIdRequest;
using Screamer.Application.Features.CommentRequest.Queries.GetCommentsByPostIdRequest;
using Screamer.Application.Features.CommentRequest.Queries.GetRepliesByCommentIdRequest;
using Screamer.Application.Features.postImageRequest.Commands;
using Screamer.Application.Features.postImageRequest.Queries;
using Screamer.Application.Features.PostRequest.Commands.CreatePostRequest;
using Screamer.Application.Features.PostRequest.Commands.DeletePostRequest;
using Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest;
using Screamer.Application.Features.PostRequest.Queries.GetAllPostsRequest;
using Screamer.Application.Features.PostRequest.Queries.GetMostRecentPostsRequest;
using Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest;
using Screamer.Application.Features.PostRequest.Queries.GetPostByUserIdRequest;
using Screamer.Application.Features.PostRequest.Queries.GetPostsByFollowingRequest;
using Screamer.Application.Features.PostRequest.Queries.GetRecommendedPostsRequest;
using Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest;
using Screamer.Application.Helpers;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    /*     [Authorize]
     */public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public PostController(IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts([FromQuery] PostParams postParams)
        {
            var query = new GetAllPostsRequestQuery { postParams = postParams };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var posts = await _mediator.Send(new GetPostByIdRequestQuery { Id = id });
            return Ok(posts);
        }

        //userid
        [HttpGet("user")]
        public async Task<IActionResult> GetPostsByUserId(
            [FromQuery] PostParams postParams,
            [FromQuery] string userId
        )
        {
            var query = new GetPostByUserIdRequestQuery
            {
                postParams = postParams,
                UserId = userId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //create
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePost(
            [FromBody] CreatePostRequestCommand createPostRequestCommandRequest
        )
        {
            var result = await _mediator.Send(createPostRequestCommandRequest);
            return Ok(result);
        }

        //update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdatePost(
            [FromBody] UpdatePostRequestCommand updatePostRequestCommand
        )
        {
            var result = await _mediator.Send(updatePostRequestCommand);
            return Ok(result);
        }

        //delete
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeletePost(int postId)
        {
            var result = await _mediator.Send(new DeletePostRequestCommand { postId = postId });
            return Ok(result);
        }

        [HttpPost("add-post-image/{postId}")]
        public async Task<ActionResult<PostImage>> AddPostImage(IFormFile file, int postId)
        {
            var command = new AddPostImageRequestCommand { file = file, postId = postId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("set-main-post-image/{postImageId}")]
        public async Task<ActionResult> SetMainPostImage(int postImageId, int postId)
        {
            var command = new SetMainPostImageRequestCommand
            {
                postImageId = postImageId,
                postId = postId
            };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete-post-image/{postImageId}")]
        public async Task<ActionResult> DeletePostImage(int postImageId, int postId)
        {
            var command = new DeletePostImageRequestCommand
            {
                postImageId = postImageId,
                postId = postId
            };
            await _mediator.Send(command);
            return NoContent();
        }

        //GetPostImageByPostIdRequestQuery
        [HttpGet("get-post-image/{postId}")]
        public async Task<ActionResult<List<PostImage>>> GetPostImageByPostId(int postId)
        {
            var query = new GetPostImageByPostIdRequestQuery { postId = postId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-posts-by-following")]
        public async Task<IActionResult> GetPostsByFollowing(
            [FromQuery] RecommendationParams recommendationParams,
            [FromQuery] string userId
        )
        {
            var query = new GetPostsByFollowingRequestQuery
            {
                recommendationParams = recommendationParams,
                userId = userId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-most-recent-posts")]
        public async Task<IActionResult> GetMostRecentPosts([FromQuery] PostParams postParams)
        {
            var query = new GetMostRecentPostsRequestQuery { postParams = postParams };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-recommended-posts")]
        public async Task<IActionResult> GetRecommendedPosts([FromQuery] PostParams postParams)
        {
            var query = new GetRecommendedPostsRequestQuery { postParams = postParams };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add-comment")]
        public async Task<IActionResult> AddComment(
            [FromBody] AddCommentRequestCommand addCommentRequestCommandRequest
        )
        {
            await _mediator.Send(addCommentRequestCommandRequest);
            return Ok();
        }

        [HttpPost("add-reply")]
        public async Task<IActionResult> AddReply(
            [FromBody] AddReplyRequestCommand addReplyRequestCommandRequest
        )
        {
            await _mediator.Send(addReplyRequestCommandRequest);
            return Ok();
        }

        [HttpDelete("delete-comment")]
        public async Task<IActionResult> DeleteComment(int postId, int commentId, string userId)
        {
            var command = new DeleteCommentRequestCommand
            {
                PostId = postId,
                CommentId = commentId,
                UserId = userId,
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("update-comment")]
        public async Task<IActionResult> UpdateComment(
            int postId,
            int commentId,
            string userId,
            string Content
        )
        {
            var command = new UpdateCommentRequestCommand
            {
                PostId = postId,
                CommentId = commentId,
                UserId = userId,
                Content = Content
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("get-comment-by-id")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var query = new GetCommentByIdRequestQuery { CommentId = commentId };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-comments-by-post-id")]
        public async Task<IActionResult> GetCommentsByPostId(
            [FromQuery] CommentParams commentParams
        )
        {
            var query = new GetCommentsByPostIdRequestQuery { CommentParams = commentParams, };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-replies-by-comment-id")]
        public async Task<IActionResult> GetRepliesByCommentId(
            [FromQuery] CommentParams commentParams
        )
        {
            var query = new GetRepliesByCommentIdRequestQuery { commentParams = commentParams, };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("get-comment-count-by-post-id")]
        public Task<IActionResult> GetCommentCountByPostId(int postId)
        {
            var count = _uow.CommentRepository.CountCommentsByPost(postId);
            return Task.FromResult<IActionResult>(Ok(count));
        }

        [HttpGet("get-most-used-hashtags")]
        public async Task<IActionResult> GetMostUsedHashtags()
        {
            var hashtags = await _uow.PostRepository.GetMostUsedHashtags();
            return Ok(hashtags);
        }

        [HttpGet("get-most-used-categories")]
        public async Task<IActionResult> GetMostUsedCategories()
        {
            var categories = await _uow.PostRepository.GetMostUsedCategories();
            return Ok(categories);
        }
    }
}
