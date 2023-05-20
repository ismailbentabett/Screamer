
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Dtos;
using Screamer.Application.Features.MessageRequest;
using Screamer.Application.Helpers;
using Screamer.Domain.Entities;
using Screamer.Presistance;

namespace HR.LeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public MessageController(IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto, string userId)
        {
            var command = new
                CreateMessageRequestCommand
            {
                createMessageDto = createMessageDto,
                userId = userId
            };


            var messageDto = await _mediator.Send(command);

            return Ok(messageDto);

        }

        [HttpGet]
        public async Task<ActionResult<PagedList<MessageDto>>> GetMessagesForUser([FromQuery]
            MessageParams messageParams,
            string userId
            )
        {
            var query = new GetMessagesForUserRequestQuery
            {
                messageParams = messageParams,
                userId = userId

            };

            var messages = await _mediator.Send(query);
            return Ok(messages);
        }
      [HttpGet("thread")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessageThread(
            string userId , 
            string currentUserId
        )
        {
            var query = new GetMessageThreadRequestQuery{
                userId = userId,
                currentUserId = currentUserId
            };
            var messages = await _mediator.Send(query);
            return Ok(messages);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(int messageId , string userId)
        {

            var command = new DeleteMessageRequestCommand{
                messageId = messageId,
                userId = userId
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}