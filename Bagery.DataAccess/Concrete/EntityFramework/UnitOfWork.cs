using Bagery.Core.Interfaces.Repositories;
using Bagery.DataAccess.Context;

namespace Bagery.DataAccess.Concrete.EntityFramework
{
    public class UnitOfWork(AppDbContext _context) : IUnitOfWork
    {
        public async Task<bool> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
