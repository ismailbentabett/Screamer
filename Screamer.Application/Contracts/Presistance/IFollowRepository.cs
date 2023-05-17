using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Dtos;
using Screamer.Application.Helpers;
using Screamer.Domain;
using Screamer.Identity.Models;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IFollowRepository :  IGenericRepository<Follow>
    {
  
        Task<Follow> GetUserFollow(string sourceUserId, string targetUserId);
        Task<ApplicationUser> GetUserWithFollows(string  userId);
        Task<PagedList<FollowDto>> GetUserFollows(FollowParams followParams); 
    }
}
