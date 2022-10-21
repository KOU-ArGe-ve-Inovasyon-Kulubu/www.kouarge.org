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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Department>> GetDepartmentWithFaculty()
        {
            return await _context.Departments.Include(x => x.Faculty).ToListAsync();
        }

        public  async Task<Department> GetByIdAsync(string id)
        {
            return await _dbSet.FindAsync(id);
        }
    
    }
}
