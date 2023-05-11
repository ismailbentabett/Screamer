/* 
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.AvatarRequest.Commands.CreateAvatarRequest
{
    public class UploadAvatarRequestHandlerCommand : IRequestHandler
    <
        CreateAvatarRequestCommand,
        int
        >
    {
        private readonly IAvatarRepository _avatarRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UploadAvatarRequestHandlerCommand(IAvatarRepository avatarRepository, IMapper mapper)
        {
            _avatarRepository = avatarRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAvatarRequestCommand request, CancellationToken cancellationToken)
        {
          
                    
       ApplicationUser user = await 
         _userRepository.GetUserByIdAsync(request.userId);

            if (user == null) throw NotFoundException("naaaah");

                

            var result = await _avatarRepository.AddPhotoAsync(request.file);

            if (result.Error != null) return BadRequestException(result.Error.Message);

            var Avatar = new Avatar
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (user.Avatars.Count == 0) Avatar.IsMain = true;

            user.Avatars.Add(Avatar);

                return Avatar.Id;

        }

        private int BadRequestException(object message)
        {
            throw new NotImplementedException();
        }

        private Exception NotFoundException(string v)
        {
            throw new NotImplementedException();
        }
    }
} */