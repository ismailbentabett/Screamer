using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Features.PostRequest.Commands.UpdateUserRequest;
using Screamer.Application.Features.PostRequest.Queries.GetPostByIdRequest;
using Screamer.Application.Features.UserRequest.Commands.DeleteUserRequest;
using Screamer.Application.Features.UserRequest.Queries.GetUserByUsernameRequest;
using Screamer.Application.Features.UserRequest.Queries.GetUsersRequest;

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
    }
}