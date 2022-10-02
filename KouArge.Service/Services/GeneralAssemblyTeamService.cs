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
    public class GeneralAssemblyTeamService : Service<GeneralAssemblyTeam>, IGeneralAssemblyTeamService
    {
        public GeneralAssemblyTeamService(IUnitOfWork unitOfWork, IGenericRepository<GeneralAssemblyTeam> repository) : base(unitOfWork, repository)
        {
        }
    }
}
