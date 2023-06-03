using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Entities;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IHashtagRepository : IGenericRepository<Hashtag> {
                Task<Hashtag> GetHashTagByNameAsync(string name);

     }
}
