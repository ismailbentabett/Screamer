using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Domain.Entities;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class CategoryRepository : GenericRepository<Category> , ICategoryRepository
    {
        public CategoryRepository(ScreamerDbContext context) : base(context)
        {
                
        }

        async Task<Category> ICategoryRepository.GetCategoryByNameAsync(string name)
        {
                    return await _context.Categories.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}