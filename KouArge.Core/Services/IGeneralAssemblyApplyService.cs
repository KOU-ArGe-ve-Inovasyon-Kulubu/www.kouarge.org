using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IGeneralAssemblyApplyService : IService<GeneralAssemblyApply>
    {
        Task<CustomResponseDto<GeneralAssemblyApplyDto>> AddAsync(string token, GeneralAssemblyApply generalAssemblyApply);
        Task DuplicateData(int eventId, string userId, int titleId);
        Task<CustomResponseDto<NoContentDto>> RemoveAsync(DeleteDto deleteDto);

        Task<CustomResponseDto<GeneralAssemblyApplyDto>> GetByUserId(int id, string Token);

    }
}
