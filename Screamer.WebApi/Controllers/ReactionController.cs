using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Features.ReactionRequest.Commands.AddReactionRequest;
using Screamer.Application.Features.ReactionRequest.Commands.RemoveReactionRequest;
using Screamer.Application.Features.ReactionRequest.Commands.UpdateReactionRequest;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-post-reaction")]
        public async Task<IActionResult> AddPostReaction(
            int postId,
            string userId,
            string reactionType
        )
        {
            var command = new AddReactionRequestCommand
            {
                UserId = userId,
                PostId = postId,
                ReactionType = reactionType,
                isPost = true
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("add-comment-reaction")]
        public async Task<IActionResult> AddCommentReaction(
            int commentId,
            string userId,
            string reactionType
        )
        {
            var command = new AddReactionRequestCommand
            {
                UserId = userId,
                CommentId = commentId,
                ReactionType = reactionType,
                isPost = false
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("delete-reaction")]
        public async Task<IActionResult> DeletePostReaction(
            int postId,
            string userId,
            string reactionType,
            bool isPost,
            int reactionId,
            int commentId
        )
        {
            var command = new RemoveReactionRequestCommand
            {
                UserId = userId,
                PostId = postId,
                ReactionType = reactionType,
                isPost = isPost,
                ReactionId = reactionId,
                CommentId = commentId
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("update-reaction")]
        public async Task<IActionResult> UpdatePostReaction(
            int postId,
            string userId,
            string reactionType,
            bool isPost,
            int reactionId,
            int commentId
        )
        {
            var command = new UpdateReactionRequestCommand
            {
                UserId = userId,
                PostId = postId,
                ReactionType = reactionType,
                isPost = isPost,
                ReactionId = reactionId,
                CommentId = commentId
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
