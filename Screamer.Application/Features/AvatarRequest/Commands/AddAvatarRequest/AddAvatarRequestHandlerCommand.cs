
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest
{
    public class AddPhotoRequestHandlerCommand : IRequestHandler
    <
        AddAvatarRequestCommand,
        int
        >
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddPhotoRequestHandlerCommand(IAvatarRepository avatarRepository, IMapper mapper,
        IUnitOfWork uow,
        IUserRepository userRepository)

        {
            _avatarRepository = avatarRepository;
            _mapper = mapper;
            _uow = uow;
            _userRepository = userRepository;

        }

        public async Task<int> Handle(AddAvatarRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.userId);

            if (user == null) throw new NotFoundException(
                nameof(ApplicationUser), request.userId);


            var result = await _avatarRepository.AddPhotoAsync(request.file);

            if (result.Error != null) throw new BadRequestException(result.Error.Message);


            var avatar = new Avatar
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            

            if (user.Avatars.Count == 0) avatar.IsMain = true;

            user.Avatars.Add(avatar);

            if (await _uow.Complete())
            {
                return avatar.Id;
            }

            throw new BadRequestException(
                "Problem adding photo");
        }
    }
}