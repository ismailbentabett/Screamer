using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest;
using Screamer.Application.Features.AvatarRequest.Commands.CreateAvatarRequest;
using Screamer.Application.Features.AvatarRequest.Commands.DeleteAvatarRequest;
using Screamer.Application.Features.PostRequest.Commands.UpdateUserRequest;
using Screamer.Application.Features.PostRequest.Queries;
using Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest;
using Screamer.Application.Features.UserRequest.Commands.DeleteUserRequest;
using Screamer.Application.Features.UserRequest.Queries.GetUserByUsernameRequest;
using Screamer.Application.Features.UserRequest.Queries.GetUsersRequest;
using Screamer.Domain.Common;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetUsersRequestQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var query = new GetUserByIdRequestQuery
            {
                Id = id
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("username/{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var query = new GetUserByUsernameRequestQuery
            {
                Username = username
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //update
        //delete

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<IActionResult> UpdateUser
(
    [FromBody] UpdateUserRequestCommand command
)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<IActionResult> DeleteUser(string id)
        {
            var command = new DeleteUserRequestCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }



        [HttpPost("add-avatar/{userId}")]
        public async Task<ActionResult<Avatar>> AddAvatar(
             IFormFile file,
[FromRoute] string? userId)
        {

            var command = new AddAvatarRequestCommand
            {

                file = file,
                userId = userId
            };
            var result = await _mediator.Send(command);
            return Ok(result);

        }


        [HttpPut("set-main-avatar/{avatarId}")]
        public async Task<ActionResult> SetMainAvatar(int avatarId,
           string? userId
           )
        {
            var command = new SetMainAvatarRequestCommand
            {
                avatarId = avatarId,
                userId = userId
            };
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("delete-avatar/{avatarId}")]
        public async Task<ActionResult> DeleteAvatar(int avatarId,
              string? userId
               )
        {
            var command = new DeleteAvatarRequestCommand
            {
                avatarId = avatarId,
                userId = userId
            };
            await _mediator.Send(command);
            return NoContent();
        }

    }

}
