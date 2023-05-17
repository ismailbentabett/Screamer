using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Helpers;
using Screamer.Domain.Common;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUserId(string userId);
        Task<PagedList<Post>> GetAllAsync(PostParams  postParams);

    }
}