using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;

namespace KouArge.Service.Services
{
    public class TeamService : Service<Team>, ITeamService
    {
        public TeamService(IUnitOfWork unitOfWork, IGenericRepository<Team> repository) : base(unitOfWork, repository)
        {
        }

    }
}
