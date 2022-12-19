using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IApplyApiService
    {
        Task<CustomResponseDto<IEnumerable<GeneralAssemblyApplyWithUserDto>>> GetAll();
        Task<CustomResponseDto<GeneralAssemblyApplyWithUserDto>> GetSingleApply(string userId, int appId);

        Task<CustomResponseDto<NoContentDto>> UpdateApply(GeneralAssemblyApplyDto applyDto);

        Task<CustomResponseDto<NoContentDto>> DeleteApply(int id);

        Task<CustomResponseDto<GeneralAssemblyApplyDto>> AddApply(GeneralAssemblyApplyDto applyDto);
    }
}
