using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Repositories
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
        public Task<IEnumerable<Department>> GetDepartmentWithFaculty();
        public  Task<Department> GetByIdAsync(string id);

    }
}
