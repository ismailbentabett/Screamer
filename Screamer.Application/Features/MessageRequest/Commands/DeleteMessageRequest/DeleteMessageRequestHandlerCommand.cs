using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Screamer.Application.Contracts.Exceptions;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Dtos;
using Screamer.Domain.Common;
using Screamer.Identity.Models;

namespace Screamer.Application.Features.MessageRequest
{
    public class DeleteMessageRequestHandlerCommand : IRequestHandler
    <
        DeleteMessageRequestCommand,
        int
        >
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _uow;

        public DeleteMessageRequestHandlerCommand(IPostRepository postRepository, IMapper mapper,
            IUnitOfWork uow
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<int> Handle(DeleteMessageRequestCommand request, CancellationToken cancellationToken)
        {
  return 1;

        }
    }
}