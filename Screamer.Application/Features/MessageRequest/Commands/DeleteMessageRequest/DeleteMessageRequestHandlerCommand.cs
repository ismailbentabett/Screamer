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
    public class DeleteMessageRequestHandlerCommand : IRequestHandler
    <
        DeleteMessageRequestCommand,
        int
        >
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public DeleteMessageRequestHandlerCommand(
            IMessageRepository messageRepository
            , IMapper mapper,
            IUnitOfWork uow
        )
        {
            _mapper = mapper;
            _uow = uow;
            _messageRepository = messageRepository;
        }

        public async Task<int> Handle(DeleteMessageRequestCommand request, CancellationToken cancellationToken)
        {
 var userId = request.userId;

            var message = await _uow.MessageRepository.GetMessage(request.messageId);

            if (message.SenderId != userId && message.RecipientId != userId) 
                throw new NotFoundException(
                    nameof(Message),
                    request.messageId
                );

            if (message.SenderId == userId) message.SenderDeleted = true;
            if (message.RecipientId == userId) message.RecipientDeleted = true;

            if (message.SenderDeleted && message.RecipientDeleted) 
            {
                _uow.MessageRepository.DeleteMessage(message);
            }

            if (await _uow.Complete()) return 
                request.messageId;

            throw new BadRequestException("Problem deleting the message");
        }
    }
}