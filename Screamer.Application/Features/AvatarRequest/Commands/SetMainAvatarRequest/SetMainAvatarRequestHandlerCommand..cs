
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Presistance;

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

        public SetMainAvatarRequestHandlerCommand(IAvatarRepository avatarRepository, IMapper mapper)
        {
            _avatarRepository = avatarRepository;
            _mapper = mapper;
        }

        public Task<int> Handle(SetMainAvatarRequestCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}