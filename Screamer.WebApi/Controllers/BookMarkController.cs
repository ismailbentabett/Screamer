using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.BookMarkRequest;
using Screamer.Application.Features.BookMarkRequest.Queries.GetBookmarkByUserIdAndPostIdRequest;
using Screamer.Application.Features.CommentRequest.Commands.DeleteCommentRequest;
using Screamer.Application.Helpers;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookMarkController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public BookMarkController(IUnitOfWork uow, IMediator mediator)
        {
            _uow = uow;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetAllBookmarksByUserId(
            [FromQuery] PostParams postParams
        )
        {
            var query = new GetAllBookmarksByUserIdRequestQuery { postParams = postParams, };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("is-bookmarked")]
        public async Task<ActionResult<bool>> GetBookmarkByUserId(string UserId, int PostId)
        {
            var query = new GetBookmarkByUserIdAndPostIdRequestQuery
            {
                UserId = UserId,
                PostId = PostId
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBookMark(AddBookMarkRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBookMark(RemoveBookMarkRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBookMark(UpdateBookMarkRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
