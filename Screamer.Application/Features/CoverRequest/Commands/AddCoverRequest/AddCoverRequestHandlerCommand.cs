
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Identity.Models;
using Microsoft.AspNetCore.Mvc;
using Screamer.Domain.Entities;
using Screamer.Application.Features.AvatarRequest.Commands.AddAvatarRequest;

namespace Screamer.Application.Features.CoverRequest.Commands.AddCoverRequest
{
    public class AddCoverRequestHandlerCommand : IRequestHandler
    <
        AddCoverRequestCommand,
        int
        >
    {
        private readonly ICoverRepository _coverRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        public AddCoverRequestHandlerCommand(ICoverRepository coverRepository, IMapper mapper,
        IUnitOfWork uow,
        IUserRepository userRepository)

        {
            _coverRepository = coverRepository;
            _mapper = mapper;
            _uow = uow;
            _userRepository = userRepository;

        }

        public async Task<int> Handle(AddCoverRequestCommand request, CancellationToken cancellationToken)
        {
            var user = await _uow.UserRepository.GetUserByIdAsync(request.userId);

            if (user == null) throw new NotFoundException(
                nameof(ApplicationUser), request.userId);


            var result = await _coverRepository.AddPhotoAsync(request.file);

            if (result.Error != null) throw new BadRequestException(result.Error.Message);


            var cover = new Cover
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            

            if (user.Covers.Count == 0) cover.IsMain = true;

            user.Covers.Add(cover);

            if (await _uow.Complete())
            {
                return cover.Id;
            }

            throw new BadRequestException(
                "Problem adding photo");
        }
    }
}