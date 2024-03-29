using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class MoodRepository : GenericRepository<Mood>, IMoodRepository
    {
        public MoodRepository(ScreamerDbContext context)
            : base(context) { }
    }
}
