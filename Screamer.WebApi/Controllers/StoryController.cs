using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Features.StoryImageRequest;
using Screamer.Application.Features.StoryRequest.Commands.AddStoryRequest;
using Screamer.Application.Features.StoryRequest.Commands.DeleteStoryRequest;
using  Screamer.Application.Features.StoryRequest;
using MediatR;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;


        public StoryController(MediatR.IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreatePost(
            [FromBody] AddStoryRequestCommand createStoryRequestCommandRequest
        )
        {
            var result = await _mediator.Send(createStoryRequestCommandRequest);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeletePost(int storyId)
        {
            var result = await _mediator.Send(new DeleteStoryRequestCommand { storyId = storyId });
            return Ok(result);
        }

        [HttpPost("add-story-image/{storyId}")]
        public async Task<ActionResult<Domain.Entities.StoryImage>> AddPostImage(
            IFormFile file,
            int storyId
        )
        {
            var command = new AddStoryImageRequestCommand { file = file, storyId = storyId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("set-main-story-image/{storyImageId}")]
        public async Task<ActionResult> SetMainPostImage(int storyImageId, int storyId)
        {
            var command = new SetMainStoryImageRequestCommand
            {
                storyImageId = storyImageId,
                storyId = storyId
            };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("delete-story-image/{storyImageId}")]
        public async Task<ActionResult> DeletePostImage(int storyImageId, int storyId)
        {
            var command = new DeleteStoryImageRequestCommand
            {
                storyImageId = storyImageId,
                storyId = storyId
            };
            await _mediator.Send(command);
            return NoContent();
        }

       [HttpGet]
        public async Task<IActionResult> GetAllStories()
        {
            var query = new GetAllStoriesRequestQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("by-following/{id}")]
        public async Task<IActionResult> GetStoriesByFollowing(string userId)
        {
            var query = new GetStoriesByFollowingRequestQuery { UserId = userId };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
 
      

    }

 
}
