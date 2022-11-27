using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IDepartmentService : IService<Department>
    {
        public Task<CustomResponseDto<IEnumerable<DepartmentWithFacultyDto>>> GetDepartmentWithFacultyAsync();
        public Task<Department> GetByIdAsync(string id);
    }

}
