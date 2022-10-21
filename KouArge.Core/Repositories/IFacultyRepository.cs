using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Repositories
{
    public interface IFacultyRepository:IGenericRepository<Faculty>
    {
        
        public Task<List<Faculty>> GetAllFacultysWithDepartmentsAsync();
        public Task<Faculty> GetSingleFacultyByIdWithDepartmentAsync(int id);
    }
}
