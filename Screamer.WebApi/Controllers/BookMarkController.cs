using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Application.Features.BookMarkRequest;
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

        
        [HttpPost]
        public async Task<ActionResult> CreateBookMark(AddBookMarkRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookMark(UpdateBookMarkRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBookMark( UpdateBookMarkRequestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
