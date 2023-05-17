using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Screamer.Domain;
using Screamer.Application.Features.FollowRequest.Commands.RemoveFollowRequest;

namespace Screamer.Application.Features.AvatarRequest.Commands.RemoveAvatarRequest
{
    public class RemoveFollowRequestHandlerCommand : IRequestHandler<RemoveFollowRequestCommand , Unit>
    {
        private readonly IUnitOfWork _uow;

        public RemoveFollowRequestHandlerCommand(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(RemoveFollowRequestCommand request, CancellationToken cancellationToken)
        {
            var followedUser = await _uow.UserRepository.GetUserByIdAsync(request.targetUserId);
            var sourceUser = await _uow.FollowRepository.GetUserWithFollows(request.sourceUserId);

            if (followedUser == null)
                throw new NotFoundException(nameof(ApplicationUser), request.targetUserId);

            if (sourceUser.Id == request.targetUserId)
                throw new BadRequestException("You cannot unfollow yourself");

            var userFollow = await _uow.FollowRepository.GetUserFollow(request.sourceUserId, followedUser.Id);

            if (userFollow == null)
                throw new BadRequestException("You do not follow this user");

            sourceUser.Following.Remove(userFollow);

            if (await _uow.Complete())
            {
                return Unit.Value;
            }

            throw new BadRequestException("Failed to unfollow user");
        }
    }
}
