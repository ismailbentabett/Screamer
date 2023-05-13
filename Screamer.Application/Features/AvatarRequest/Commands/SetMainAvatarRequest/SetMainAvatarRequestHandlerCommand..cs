
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.AvatarRequest.Commands.CreateAvatarRequest
{
    public class SetMainAvatarRequestHandlerCommand : IRequestHandler
    <
        SetMainAvatarRequestCommand,
        int
        >
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public SetMainAvatarRequestHandlerCommand(IAvatarRepository avatarRepository, IMapper mapper,
            IUserRepository userRepository, IUnitOfWork uow
        )
        {
            _avatarRepository = avatarRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _uow = uow;
        }

        public async Task<int> Handle(SetMainAvatarRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.userId);

            if (user == null) throw new NotFoundException(
                nameof(ApplicationUser), request.userId

            );

            var avatar = user.Avatars.FirstOrDefault(x => x.Id == request.avatarId);

            if (avatar == null) throw new NotFoundException(
                nameof(Avatar), request.userId

            );

            if (avatar.IsMain) throw new BadRequestException("this is already your main photo");

            var currentMain = user.Avatars.FirstOrDefault(x => x.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            avatar.IsMain = true;
            if (
                  await _uow.Complete()
              )
            {
                return avatar.Id;
            }
            else
            {
                throw new Exception("problem saving changes");
            }
        }
    }

}