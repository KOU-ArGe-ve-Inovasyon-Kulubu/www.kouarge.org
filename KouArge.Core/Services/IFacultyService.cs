using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services
{
    public interface IFacultyService:IService<Faculty>
    {
        public Task<CustomResponseDto<List<FacultyWithDepartmentsDto>>> GetAllFacultysWithDepartmentsAsync();
        public Task<CustomResponseDto<FacultyWithDepartmentsDto>> GetSingleFacultyByIdWithDepartmentAsync(int id);
    }
}
