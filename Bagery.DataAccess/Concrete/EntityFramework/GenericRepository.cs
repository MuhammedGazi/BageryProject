using Bagery.Core.Interfaces.Repositories;
using Bagery.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Bagery.DataAccess.Concrete.EntityFramework
{
    public class GenericRepository<T>(AppDbContext _context) : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _table = _context.Set<T>();
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _table.AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _table.AsQueryable();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }

    }
}
