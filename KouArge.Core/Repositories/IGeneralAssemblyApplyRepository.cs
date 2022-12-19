using KouArge.Core.Models;
using System.Collections.Generic;

namespace KouArge.Core.Repositories
{
    public interface IGeneralAssemblyApplyRepository : IGenericRepository<GeneralAssemblyApply>
    {
        Task<bool> DuplicateData(int teamId, string userId, int titleId);
        Task<GeneralAssemblyApply> GetByUserId(string userId, int Id);

        IQueryable<GeneralAssemblyApply> GetAllWithUser();
    }
}
