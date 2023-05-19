using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;
using Screamer.Identity.Models;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IReactionRepository :  IGenericRepository<Reaction>
    {
         Reaction GetReactionById(int reactionId);
    void AddReaction(Reaction reaction);
    void RemoveReaction(Reaction reaction);
    List<Reaction> GetReactionsByPost(Post post);
    List<Reaction> GetReactionsByUser(ApplicationUser user);
    }
}