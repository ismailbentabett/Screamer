using Screamer.Application.Contracts.Presistance;
using Screamer.Presistance.Repositories;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IUnitOfWork
    {

        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IAvatarRepository AvatarRepository { get; }

        IMessageRepository MessageRepository { get; }
        IFollowRepository FollowRepository { get; }

        IReactionRepository ReactionRepository { get; }

        ICoverRepository CoverRepository { get; }

        IPostImageRepository PostImageRepository  {get;}

        Task<bool> Complete();
        bool HasChanges();
    }
}