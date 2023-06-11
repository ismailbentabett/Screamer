using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Features.StoryImageRequest;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : ControllerBase
    {

   private readonly MediatR.IMediator _mediator;
        private readonly IUnitOfWork _uow;

        public StoryController(MediatR.IMediator mediator, IUnitOfWork uow)
        {
            _mediator = mediator;
            _uow = uow;
        }

       
        [HttpPost("add-story-image/{storyId}")]
        public async Task<ActionResult<Domain.Entities.StoryImage>> AddPostImage(IFormFile file, int storyId)
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
    }
}