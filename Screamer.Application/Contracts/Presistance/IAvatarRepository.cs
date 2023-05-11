using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Domain.Common;

namespace Screamer.Application.Contracts.Presistance
{
    public interface IAvatarRepository : IGenericRepository<Avatar>
    {
        Task<IEnumerable<Avatar>> GetAvatarsByUserId(int userId);
    }
}