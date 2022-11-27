using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public IQueryable<Faculty> GetAllFacultysWithDepartmentsAsync()
        {
            return _context.Faculties.Include(x => x.Departments).AsQueryable();
        }

        public async Task<Faculty> GetSingleFacultyByIdWithDepartmentAsync(int FacultyId)
        {
            return await _context.Faculties.Include(x => x.Departments).Where(x => x.Id == FacultyId).SingleOrDefaultAsync();
        }
    }
}
