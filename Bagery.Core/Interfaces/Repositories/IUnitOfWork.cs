namespace Bagery.Core.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangeAsync();
    }
}
