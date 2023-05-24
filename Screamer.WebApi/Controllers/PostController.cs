using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Features.postImageRequest.Commands;
using Screamer.Application.Features.PostRequest.Commands.CreatePostRequest;
using Screamer.Application.Features.PostRequest.Commands.DeletePostRequest;
using Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest;
using Screamer.Application.Features.PostRequest.Queries.GetAllPostsRequest;
using Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest;
using Screamer.Application.Features.PostRequest.Queries.GetPostByUserIdRequest;
using Screamer.Application.Helpers;
using Screamer.Domain.Entities;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<ActionResult<PostImage>> AddAvatar(IFormFile file, [FromRoute] int postId)
        {
            var command = new AddPostImageRequestCommand { file = file, postId = postId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("set-main-post-image/{postImageId}")]
        public async Task<ActionResult> SetMainAvatar(int postImageId, int postId)
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
        public async Task<ActionResult> DeleteAvatar(int postImageId, int postId)
        {
            var command = new DeletePostImageRequestCommand
            {
                postImageId = postImageId,
                postId = postId
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
