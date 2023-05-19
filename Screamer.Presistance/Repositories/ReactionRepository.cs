using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly ScreamerDbContext _dbContext;
        public ReactionRepository(ScreamerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddReaction(Reaction reaction)
        {
            _dbContext.Reactions.Add(reaction);

        }

        public Reaction GetReactionById(int reactionId)
        {
            return _dbContext.Reactions.FirstOrDefault(r => r.Id == reactionId);
        }

        public List<Reaction> GetReactionsByPost(Post post)
        {
            return
               _dbContext.Reactions.Where(r => r.PostId == post.Id).ToList();
        }

        public List<Reaction> GetReactionsByUser(ApplicationUser user)
        {
            return
                _dbContext.Reactions.Where(r => r.UserId == user.Id).ToList();  
                        }

        public void RemoveReaction(Reaction reaction)
        {
            _dbContext.Reactions.Remove(reaction);
        }
    }
}