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
 var username = request.userName;

            if (username == request.createMessageDto.RecipientUsername.ToLower())
                throw new BadRequestException("You cannot send messages to yourself");

            var sender = await _uow.UserRepository.GetUserByUsernameAsync(username);
            var recipient = await _uow.UserRepository.GetUserByUsernameAsync(request.createMessageDto.RecipientUsername);

            if (recipient == null)  throw new NotFoundException(
                nameof(ApplicationUser),
                request.createMessageDto.RecipientUsername
            );

            var message = new Message
            {
                Sender = sender,
                Recipient = recipient,
                SenderUsername = sender.UserName,
                RecipientUsername = recipient.UserName,
                Content = request.createMessageDto.Content
            };

            _uow.MessageRepository.AddMessage(message);

            if (await _uow.Complete()) return 
                _mapper.Map<MessageDto>(message);

            throw new BadRequestException("Failed to send message");
        }
    }
}