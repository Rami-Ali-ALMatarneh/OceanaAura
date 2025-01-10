using Microsoft.EntityFrameworkCore;
using OceanaAura.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public IQueryable<T> Query()
        {
            return _dbSet.AsNoTracking(); 
        }

        public async Task<int> CountAsync(IQueryable<T> query)
        {
            return await query.CountAsync();
        }

        public async Task<List<T>> ToListAsync(IQueryable<T> query)
        {
            return await query.ToListAsync();
        }

        public void ReomveRange(List<T> entities)
        {
            _context.RemoveRange(entities);
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }
    }
}
