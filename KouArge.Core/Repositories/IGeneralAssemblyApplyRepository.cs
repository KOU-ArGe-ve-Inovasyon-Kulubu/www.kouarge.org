using KouArge.Core.Models;

namespace KouArge.Core.Repositories
{
    public interface IGeneralAssemblyApplyRepository : IGenericRepository<GeneralAssemblyApply>
    {
        Task<bool> DuplicateData(int teamId, string userId, int titleId);
        Task<GeneralAssemblyApply> GetByUserId(string userId, int Id);
    }
}
