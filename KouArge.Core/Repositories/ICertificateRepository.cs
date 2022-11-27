using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface ICertificateRepository : IGenericRepository<Certificate>
    {
        Task<Certificate> GetByIdAsync(string id);
        Task<Certificate> GetByIdWithDetailsAsync(string id);

        IQueryable<Certificate> GetAllWithDetails();

        Task<bool> DuplicateData(int eventId, string userId);
    }
}
