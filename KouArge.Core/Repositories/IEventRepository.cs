using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        IQueryable<Event> GetAllWithDetails();
        Task<Event> GetByIdWithDetailsAsync(int id);

    }
}
