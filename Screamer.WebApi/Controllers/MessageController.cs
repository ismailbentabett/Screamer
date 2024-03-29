using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Dtos;
using Screamer.Application.Features.MessageRequest;
using Screamer.Application.Features.MessageRequest.Commands.CreateRoomRequest;
using Screamer.Application.Features.MessageRequest.Queries.GetChatRoomByIdRequest;
using Screamer.Application.Features.MessageRequest.Queries.GetUserChatRoomsRequest;
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

        public MessageController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(
            CreateMessageDto createMessageDto,
            string userId
        )
        {
            var command = new CreateMessageRequestCommand
            {
                createMessageDto = createMessageDto,
                userId = userId
            };

            var messageDto = await _mediator.Send(command);

            return Ok(messageDto);
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<MessageDto>>> GetMessagesForUser(
            [FromQuery] MessageParams messageParams,
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
            string userId,
            string currentUserId,
            [FromQuery] MessageParams messageParams
        )
        {
            var query = new GetMessageThreadRequestQuery
            {
                userId = userId,
                currentUserId = currentUserId,
                messageParams = messageParams
            };
            var messages = await _mediator.Send(query);
            return Ok(messages);
        }

        //get user threads
        [HttpGet("threads")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetUserThreads(
            string userId,
            [FromQuery] MessageParams messageParams
        )
        {
            var query = new GetUserChatRoomsRequestQuery
            {
                userId = userId,
                messageParams = messageParams
            };
            var messages = await _mediator.Send(query);
            return Ok(messages);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(int messageId, string userId)
        {
            var command = new DeleteMessageRequestCommand
            {
                messageId = messageId,
                userId = userId
            };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("thread/{id}")]
        public async Task<ActionResult> GetChatRoomById(int id)
        {
            var command = new GetChatRoomByIdRequestQuery { ChatRoomId = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("createRoom")]
        public async Task<ActionResult> CreateRoom(string userId, string recipientId)
        {
            var command = new CreateRoomRequestCommand
            {
                userId = userId,
                recipientId = recipientId
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
