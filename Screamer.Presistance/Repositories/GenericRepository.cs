using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Screamer.Application.Contracts.Presistance;
using Screamer.Presistance.DatabaseContext;

namespace Screamer.Presistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
           protected readonly  ScreamerDbContext _context;

        public GenericRepository(ScreamerDbContext context)
        {
            _context = context;
        }


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
              .AsNoTracking()
                .FirstOrDefaultAsync(e => e.GetType().GetProperty("Id").GetValue(e).ToString() == id.ToString());
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }


    }
}