using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;
using Screamer.Presistance.Repositories;

namespace Screamer.Application.Features.MessageRequest.Commands.CreateRoomRequest
{
    public class CreateRoomRequestHandlerCommand : IRequestHandler<CreateRoomRequestCommand, int>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public CreateRoomRequestHandlerCommand(
            IMessageRepository messageRepository,
            IMapper mapper,
            IUnitOfWork uow
        )
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            CreateRoomRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var userId = request.userId;

            if (userId == request.recipientId)
                throw new BadRequestException("You cannot send messages to yourself");

            var sender = await _uow.UserRepository.GetUserByIdAsync(userId);
            var recipient = await _uow.UserRepository.GetUserByIdAsync(request.recipientId);

            if (recipient == null)
                throw new NotFoundException(nameof(ApplicationUser), request.recipientId);

            var chatRoom = await _uow.MessageRepository.GetChatRoomForUsers(
                sender.Id,
                recipient.Id
            );

            if (chatRoom == null)
            {
                chatRoom = new ChatRoom
                {
                    ChatRoomUsers = new List<ChatRoomUser>
                    {
                        new ChatRoomUser
                        {
                            ChatRoom = chatRoom,
                            User = sender,
                            UserId = sender.Id
                        },
                        new ChatRoomUser
                        {
                            ChatRoom = chatRoom,
                            User = recipient,
                            UserId = recipient.Id
                        }
                    }
                };

                _uow.MessageRepository.AddChatRoom(chatRoom);
                if (await _uow.Complete())
                    return chatRoom.Id;
            }

            return chatRoom.Id;
        }
    }
}
