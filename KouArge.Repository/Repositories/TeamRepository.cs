using KouArge.Core.Models;
using KouArge.Core.Repositories;

namespace KouArge.Repository.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(AppIdentityDbContext context) : base(context)
        {
        }


    }
}
