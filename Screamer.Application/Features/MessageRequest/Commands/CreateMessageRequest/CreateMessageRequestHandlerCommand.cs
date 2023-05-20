using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;
using Screamer.Presistance.Repositories;

namespace Screamer.Application.Features.MessageRequest
{
    public class CreateMessageRequestHandlerCommand : IRequestHandler
    <
        CreateMessageRequestCommand,
        MessageDto
        >
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public CreateMessageRequestHandlerCommand(
            IMessageRepository messageRepository
            , IMapper mapper,
            IUnitOfWork uow
        )
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<MessageDto> Handle(CreateMessageRequestCommand request, CancellationToken cancellationToken)
        {
 var userId = request.userId;

            if (userId == request.createMessageDto.RecipientId)
                throw new BadRequestException("You cannot send messages to yourself");

            var sender = await _uow.UserRepository.GetUserByIdAsync(userId);
            var recipient = await _uow.UserRepository.GetUserByIdAsync(request.createMessageDto.RecipientId);

            if (recipient == null)  throw new NotFoundException(
                nameof(ApplicationUser),
                request.createMessageDto.RecipientId
            );

            var message = new Message
            {
                Sender = sender,
                Recipient = recipient,
                SenderId = sender.Id,
                RecipientId = recipient.Id,
                Content = request.createMessageDto.Content
            };

            _uow.MessageRepository.AddMessage(message);

            if (await _uow.Complete()) return 
                _mapper.Map<MessageDto>(message);

            throw new BadRequestException("Failed to send message");
        }
    }
}