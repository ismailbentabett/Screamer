
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
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto, string userName)
        {
            var command = new
                CreateMessageRequestCommand
            {
                createMessageDto = createMessageDto,
                userName = userName
            };


            var messageDto = await _mediator.Send(command);

            return Ok(messageDto);

        }

        [HttpGet]
        public async Task<ActionResult<PagedList<MessageDto>>> GetMessagesForUser([FromQuery]
            MessageParams messageParams,
            string userName
            )
        {
            var query = new GetMessagesForUserRequestQuery
            {
                messageParams = messageParams,
                userName = userName

            };

            var messages = await _mediator.Send(query);
            return Ok(messages);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(int messageId , string userName)
        {

            var command = new DeleteMessageRequestCommand{
                messageId = messageId,
                userName = userName
            };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}