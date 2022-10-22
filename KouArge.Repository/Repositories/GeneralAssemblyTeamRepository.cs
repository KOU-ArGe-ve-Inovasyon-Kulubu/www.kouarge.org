using KouArge.Core.Models;
using KouArge.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Repository.Repositories
{
    public class GeneralAssemblyTeamRepository : GenericRepository<GeneralAssemblyTeam>, IGeneralAssemblyTeamRepository
    {
        public GeneralAssemblyTeamRepository(AppIdentityDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<GeneralAssemblyTeam>> GetGeneralAssemblyTeamWithGeneralAssembly()
        {
            return await _context.GeneralAssemblyTeams.Include(x => x.GeneralAssembly).ToListAsync();
        }
    }
}
