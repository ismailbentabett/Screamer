using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Common;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class AvatarRepository : GenericRepository<Avatar>, IAvatarRepository
    {
        public AvatarRepository(ScreamerDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Avatar>> GetAvatarsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
        

    }
}