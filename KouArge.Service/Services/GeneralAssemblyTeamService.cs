using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Repository.Repositories;
using KouArge.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class GeneralAssemblyTeamService : Service<GeneralAssemblyTeam>, IGeneralAssemblyTeamService
    {
        private readonly IGeneralAssemblyTeamRepository _generalAssemblyTeamRepository;
        private readonly IMapper _mapper;

        public GeneralAssemblyTeamService(IUnitOfWork unitOfWork, IGenericRepository<GeneralAssemblyTeam> repository, IGeneralAssemblyTeamRepository generalAssemblyTeamRepository,IMapper mapper) : base(unitOfWork, repository)
        {
            _generalAssemblyTeamRepository = generalAssemblyTeamRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<IEnumerable<GeneralAssemblyTeamWithGeneralAssemblyDto>>> GetDepartmentWithFacultyAsync()
        {
            var generalAssemblyTeam = await _generalAssemblyTeamRepository.GetGeneralAssemblyTeamWithGeneralAssembly();
            var generalAssemblyTeamDto = _mapper.Map<IEnumerable<GeneralAssemblyTeamWithGeneralAssemblyDto>>(generalAssemblyTeam.ToList());
            return CustomResponseDto<IEnumerable<GeneralAssemblyTeamWithGeneralAssemblyDto>>.Success(200, generalAssemblyTeamDto);
        }
    }
}
