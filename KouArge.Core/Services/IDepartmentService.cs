﻿using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services
{
    public interface IDepartmentService : IService<Department>
    {
        public Task<CustomResponseDto<IEnumerable<DepartmentWithFacultyDto>>> GetDepartmentWithFacultyAsync();
        public Task<Department> GetByIdAsync(string id);
    }

}
