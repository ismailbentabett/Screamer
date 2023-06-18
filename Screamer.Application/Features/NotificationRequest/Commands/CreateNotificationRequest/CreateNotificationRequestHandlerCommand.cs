using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.NotificationRequest.Commands.CreateNotificationRequest
{
    public class CreateNotificationRequestHandlerCommand
        : IRequestHandler<CreateNotificationRequestCommand, int>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public CreateNotificationRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(
            CreateNotificationRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var notification = await _uow.NotificationRepository.AddAsync(
                _mapper.Map<Notification>(request)
            );

            await _uow.Complete();

            return notification.Id;
        }
    }
}
