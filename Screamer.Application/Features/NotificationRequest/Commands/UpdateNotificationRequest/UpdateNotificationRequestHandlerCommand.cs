using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;

namespace Screamer.Application.Features.NotificationRequest.Commands.UpdateNotificationRequest
{
    public class UpdateNotificationRequestHandlerCommand
        : IRequestHandler<UpdateNotificationRequestCommand, Unit>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public UpdateNotificationRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Unit> Handle(
            UpdateNotificationRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var notification = await _uow.NotificationRepository.GetByIdAsync(
                request.NotificationId
            );

            await _uow.NotificationRepository.UpdateAsync(_mapper.Map<Notification>(request));

            await _uow.Complete();

            return Unit.Value;
        }
    }
}
