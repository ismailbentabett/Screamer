using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Entities;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IStoryRepository : IGenericRepository<Story>
    {
        Task<Story> GetStoryByIdAsync(int id);

        Task<List<Story>> GetAllStoriesAsync();

        Task<List<Story>> GetStoriesByFollowingAsync(string userId);
    }
}
