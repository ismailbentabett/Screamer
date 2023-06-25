using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Features.NotificationRequest.Commands.CreateNotificationRequest;
using Screamer.Application.Features.NotificationRequest.Commands.DeleteNotificationRequest;
using Screamer.Application.Features.NotificationRequest.Commands.UpdateNotificationRequest;
using Screamer.Application.Features.NotificationRequest.Queries.GetNotificationByIdRequest;
using Screamer.Application.Features.NotificationRequest.Queries.GetNotificationsByUserIdRequest;
using Screamer.Application.Helpers;

namespace Screamer.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotificationsByUserId(
            [FromQuery] NotificationParams notificationParams,
            [FromQuery] string userId
        )
        {
            var query = new GetNotificationsByUserIdRequestQuery
            {
                notificationParams = notificationParams,
            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetNotificationById(
            [FromQuery] GetNotificationByIdRequestQuery GetNotificationByIdRequestQuery
        )
        {
            var result = await _mediator.Send(GetNotificationByIdRequestQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(
            CreateNotificationRequestCommand createNotificationRequestCommand
        )
        {
            var result = await _mediator.Send(createNotificationRequestCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNotification(
            [FromQuery] DeleteNotificationRequestCommand deleteNotificationRequestCommand
        )
        {
            var result = await _mediator.Send(deleteNotificationRequestCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNotification(
            [FromBody] UpdateNotificationRequestCommand updateNotificationRequestCommand
        )
        {
            var result = await _mediator.Send(updateNotificationRequestCommand);
            return Ok(result);
        }
    }
}
