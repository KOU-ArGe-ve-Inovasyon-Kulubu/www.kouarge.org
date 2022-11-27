using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface IFacultyRepository : IGenericRepository<Faculty>
    {

        public IQueryable<Faculty> GetAllFacultysWithDepartmentsAsync();
        public Task<Faculty> GetSingleFacultyByIdWithDepartmentAsync(int id);
    }
}
