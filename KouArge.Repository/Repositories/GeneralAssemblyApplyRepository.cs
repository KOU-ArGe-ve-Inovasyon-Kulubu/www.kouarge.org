using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Repository.Repositories
{
    public class GeneralAssemblyApplyRepository : GenericRepository<GeneralAssemblyApply>, IGeneralAssemblyApplyRepository
    {
        public GeneralAssemblyApplyRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<GeneralAssemblyApply> GetByUserId(string userId,int Id)
        {
            return await _context.GeneralAssemblyApplies.Where(x => x.Id == Id && x.AppUserId == userId).FirstOrDefaultAsync();
        }
        public async Task<bool> DuplicateData(int teamId, string userId, int titleId)
        {
            return await _context.GeneralAssemblyApplies.AnyAsync(x => x.TeamId == teamId && x.AppUserId == userId && x.TitleId == titleId && x.AppStatus == 0 || x.AppStatus == 1);

            //return await _context.GeneralAssemblyApplies.FirstOrDefaultAsync(x => x.TeamId == teamId && x.AppUserId == userId && x.TitleId == titleId && x.AppStatus == 0 || x.AppStatus == 1);
        }
    }

}
