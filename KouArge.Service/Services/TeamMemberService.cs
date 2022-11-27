using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;

namespace KouArge.Service.Services
{
    public class TeamMemberService : Service<TeamMember>, ITeamMemberService
    {
        public TeamMemberService(IUnitOfWork unitOfWork, IGenericRepository<TeamMember> repository) : base(unitOfWork, repository)
        {
        }

    }
}
