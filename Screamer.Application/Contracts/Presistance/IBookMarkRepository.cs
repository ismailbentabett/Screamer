using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Helpers;
using Screamer.Domain.Common;
using Screamer.Domain.Entities;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IBookMarkRepository : IGenericRepository<BookMark>
    {
        Task<PagedList<Post>> GetAllBookmarksByUserIdRequest(PostParams postParams);
        Task<BookMark> GetBookmarkByUserIdAndPostId(string UserId, int PostId);
    }
}
