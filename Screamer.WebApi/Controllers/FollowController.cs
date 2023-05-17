using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FollowController : ControllerBase
    {
        
 private readonly IUnitOfWork _uow;
        public FollowController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpPost("{username}")]
        public async Task<ActionResult> AddFollow(string targetUserId , string sourceUserId)
        {
            var followedUser = await _uow.UserRepository.GetUserByIdAsync(targetUserId);
            var sourceUser = await _uow.FollowRepository.GetUserWithFollows(sourceUserId);

            if (followedUser == null) return NotFound();

            if (sourceUser.Id == sourceUserId) return BadRequest("You cannot like yourself");

            var userFollow = await _uow.FollowRepository.GetUserFollow(sourceUserId, followedUser.Id);

            if (userFollow != null) return BadRequest("You already like this user");

            userFollow = new Domain.Follow
            {
                SourceUserId = sourceUserId,
                TargetUserId = followedUser.Id
            };

            sourceUser.Following.Add(userFollow);

            if (await _uow.Complete()) return Ok();

            return BadRequest("Failed to like user");
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<FollowDto>>> GetUserFollows([FromQuery]FollowParams followParams , string userId)
        {
            followParams.UserId = userId;

            var users = await _uow.FollowRepository.GetUserFollows(followParams);

            Response.AddPaginationHeader(new PaginationHeader(users.CurrentPage, 
                users.PageSize, users.TotalCount, users.TotalPages));

            return Ok(users);
        }
    }
}