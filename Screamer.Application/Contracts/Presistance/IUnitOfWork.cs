using Screamer.Application.Contracts.Presistance;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IUnitOfWork
    {
            
        IUserRepository UserRepository { get; }
        IPostRepository PostRepository { get; }
        IAvatarRepository AvatarRepository { get; }

        Task<bool> Complete();
        bool HasChanges();
    }
}