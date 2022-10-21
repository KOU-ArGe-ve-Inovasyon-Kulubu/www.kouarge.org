using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class TeamMemberService : Service<TeamMember>, ITeamMemberService
    {
        public TeamMemberService(IUnitOfWork unitOfWork, IGenericRepository<TeamMember> repository) : base(unitOfWork, repository)
        {
        }

    }
}
