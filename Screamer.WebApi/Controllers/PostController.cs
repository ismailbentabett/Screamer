using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Features.PostRequest.Commands.CreatePostRequest;
using Screamer.Application.Features.PostRequest.Commands.DeletePostRequest;
using Screamer.Application.Features.PostRequest.Commands.UpdatePostRequest;
using Screamer.Application.Features.PostRequest.Queries.GetAllPostsRequest;
using Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest;
using Screamer.Application.Features.PostRequest.Queries.GetPostByUserIdRequest;
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
        public async Task<IActionResult> GetAllPosts()
        {
            var query = new GetAllPostsRequestQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var posts = await _mediator.Send(new GetPostByIdRequestQuery
            {
                Id = id
            });
            return Ok(posts);
        }

        //userid 
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetPostsByUserId(int id)
        {
            var query = new GetPostByUserIdRequestQuery
            {
                UserId = id
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        //create 
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostRequestCommand createPostRequestCommandRequest)
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
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostRequestCommand updatePostRequestCommand)
        {
            var result = await _mediator.Send(updatePostRequestCommand);
            return Ok(result);
        }

        //delete
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeletePost(int id)
        {
            var result = await _mediator.Send(new DeletePostRequestCommand
            {
                Id = id
            });
            return Ok(result);
        }

    } 
}