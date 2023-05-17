using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest;
using Screamer.Application.Helpers;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowController : ControllerBase
    {

        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public FollowController(IUnitOfWork uow,
        IMediator mediator
        )
        {
            _uow = uow;
            _mediator = mediator;
        }

        [HttpPost("{targetUserId}")]
        public async Task<ActionResult> AddFollow(string targetUserId, string sourceUserId)
        {

            var command = new
                AddFollowRequestCommand
            {
                targetUserId = targetUserId,
                sourceUserId = sourceUserId
            };

            await _mediator.Send(command);

            return Ok();

        }

        [HttpGet]
        public async Task<ActionResult<PagedList<FollowDto>>> GetUserFollows([FromQuery] FollowParams followParams, string userId)
        {
            followParams.UserId = userId;

            var users = await _uow.FollowRepository.GetUserFollows(followParams);

            Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage,
                users.PageSize, users.TotalCount, users.TotalPages));

            return Ok(users);
        }
    }
}