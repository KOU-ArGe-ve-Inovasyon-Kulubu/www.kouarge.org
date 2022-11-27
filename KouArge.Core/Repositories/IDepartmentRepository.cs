using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public IQueryable<Department> GetDepartmentWithFaculty();
        public Task<Department> GetByIdAsync(string id);

    }
}
