using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Screamer.Application.Contracts.Presistance;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ScreamerDbContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(ScreamerDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context, _mapper);

        public IPostRepository PostRepository => new PostRepository(_context);

        public IAvatarRepository AvatarRepository => throw new NotImplementedException();
        public ICoverRepository CoverRepository => throw new NotImplementedException();
        public IPostImageRepository PostImageRepository => throw new NotImplementedException();
        public ICommentRepository CommentRepository => new CommentRepository(_context);

        public IMessageRepository MessageRepository => new MessageRepository(_context, _mapper);

        public IFollowRepository FollowRepository => new FollowRepository(_context, _mapper);

        public IReactionRepository ReactionRepository => new ReactionRepository(_context);

        public IHashtagRepository HashtagRepository => new HashtagRepository(_context);

        public IMoodRepository MoodRepository => new MoodRepository(_context);

        public ICategoryRepository CategoryRepository => new CategoryRepository(_context);

        public IStoryRepository StoryRepository => new StoryRepository(_context);

        public IBookMarkRepository BookMarkRepository => new BookMarkRepository(_context);

        public IStoryImageRepository StoryImageRepository => throw new NotImplementedException();

        public async Task<bool> Complete()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
    }
}
