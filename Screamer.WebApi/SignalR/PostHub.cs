using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Screamer.Application.Contracts.Presistance;
using Screamer.Application.Helpers;

namespace Screamer.WebApi.SignalR
{
    [Authorize]
    public class PostHub : Hub
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        //logger
        private readonly ILogger<PostHub> _logger;
        private readonly IMediator _mediator;

        public PostHub(IUnitOfWork uow, IMapper mapper, ILogger<PostHub> logger, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
            _mediator = mediator;
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var User = httpContext.Request.Query["user"];

            await Clients.Caller.SendAsync("User", User);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinUserPostRoom(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
            await Clients.Group(userId).SendAsync("JoinUserPostRoom", userId);

            await Clients.Client(Context.ConnectionId).SendAsync("JoinRoom", userId);
        }

        public async Task LeaveUserPostRoom(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId.ToString());

            await Clients.Group(userId.ToString()).SendAsync("LeaveUserPostRoom", userId);
        }

        public async Task GetPostsByFollowing(
            string userId,
            RecommendationParams recommendationParams
        )
        {
            var posts = await _uow.PostRepository.GetPostsByFollowing(userId, recommendationParams);

            await Clients.Group(userId).SendAsync("GetPostsByFollowing", posts);
        }

        public async Task GetMostRecentPosts(PostParams postParams)
        {
            var posts = await _uow.PostRepository.GetMostRecentPosts(postParams);

            await Clients.All.SendAsync("GetMostRecentPosts", posts);
        }

        public async Task GetRecommendedPosts(PostParams postParams)
        {
            var posts = await _uow.PostRepository.GetRecommendedPosts(postParams);

            await Clients.All.SendAsync("GetRecommendedPosts", posts);
        }
    }
}
