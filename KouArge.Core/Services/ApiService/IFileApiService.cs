using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IFileApiService
    {
        Task<CustomResponseDto<FilePathDto>> Upload(HttpContent data);
    }
}
