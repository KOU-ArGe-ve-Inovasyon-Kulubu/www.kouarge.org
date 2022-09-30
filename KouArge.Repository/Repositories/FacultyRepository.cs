using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Repositories
{
    public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<List<Faculty>> GetAllFacultysWithDepartmentsAsync()
        {
            return await _context.Faculties.Include(x => x.Departments).ToListAsync();
        }

        public async Task<Faculty> GetSingleFacultyByIdWithDepartmentAsync(int FacultyId)
        {
            return await _context.Faculties.Include(x => x.Departments).Where(x => x.Id == FacultyId).SingleOrDefaultAsync();
        }
    }
}
