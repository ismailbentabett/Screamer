using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Entities;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IStoryRepository : IGenericRepository<Story>
    {
            //get story by id 
            Task<Story> GetStoryByIdAsync(int id);
    }
}