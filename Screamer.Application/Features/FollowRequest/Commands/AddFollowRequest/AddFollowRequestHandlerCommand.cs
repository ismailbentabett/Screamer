
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest
{
    public class AddFollowRequestHandlerCommand : IRequestHandler
    <
        AddFollowRequestCommand,
        int
        >
    {

        private readonly IUnitOfWork _uow;

        public AddFollowRequestHandlerCommand(
        IUnitOfWork uow)

        {

            _uow = uow;

        }

        public async Task<int> Handle(AddFollowRequestCommand request, CancellationToken cancellationToken)
        {
            var followedUser = await _uow.UserRepository.GetUserByIdAsync(request.targetUserId);
            var sourceUser = await _uow.FollowRepository.GetUserWithFollows(request.sourceUserId);

            if (followedUser == null) throw new NotFoundException(
                nameof(ApplicationUser),
                request.targetUserId
            );  

            if (sourceUser.Id == request.sourceUserId) throw new BadRequestException("You cannot like yourself");

            var userFollow = await _uow.FollowRepository.GetUserFollow(request.sourceUserId, followedUser.Id);

            if (userFollow != null) throw new BadRequestException("You already like this user");

            userFollow = new Domain.Follow
            {
                SourceUserId = request.sourceUserId,
                TargetUserId = followedUser.Id
            };

            sourceUser.Following.Add(userFollow);

            if (await _uow.Complete()) {
                return userFollow.Id;
            }

            throw new BadRequestException("Failed to like user");
 
        }
    }
}