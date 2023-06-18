using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;

namespace Screamer.Application.Features.NotificationRequest.Commands.DeleteNotificationRequest
{
    public class DeleteNotificationRequestHandlerCommand
        : IRequestHandler<DeleteNotificationRequestCommand, Unit>
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public DeleteNotificationRequestHandlerCommand(IMapper mapper, IUnitOfWork uow)
        {
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<Unit> Handle(
            DeleteNotificationRequestCommand request,
            CancellationToken cancellationToken
        )
        {
            var notification = await _uow.NotificationRepository.GetByIdAsync(
                request.NotificationId
            );

            await _uow.NotificationRepository.DeleteAsync(notification);

            await _uow.Complete();

            return Unit.Value;
        }
    }
}
