using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IDepartmentApiService
    {
        public   Task<CustomResponseDto<List<DepartmentWithFacultyDto>>> GetDepartmentWithFacultyAsync();


        public   Task<DepartmentDto> Save(DepartmentDto departmentDto);


        public   Task<DepartmentDto> GetByIdAsync(IdDto<string> data);
 

        public   Task<bool> UpdateAsync(DepartmentDto departmentDto);


        public   Task<bool> DeleteAsync(int id);
       

    }
}
