using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public IQueryable<Department> GetDepartmentWithFaculty()
        {
            return _context.Departments.Include(x => x.Faculty).AsQueryable().AsNoTracking();
        }

        public async Task<Department> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }

    }
}
