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


        Task<bool> Complete();
        bool HasChanges();
    }
}