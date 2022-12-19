using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.UnitOfWorks;
using KouArge.Repository.Repositories;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class TeamMemberService : Service<TeamMember>, ITeamMemberService
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;
        public TeamMemberService(IUnitOfWork unitOfWork, IGenericRepository<TeamMember> repository, ITeamMemberRepository teamMemberRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetAllWithDetails()
        {
            var data = await _teamMemberRepository.GetAllWithDetails().ToListAsync();
            var dataDto = _mapper.Map<IEnumerable<AppUserWithTeamDto>>(data);

            return CustomResponseDto<IEnumerable<AppUserWithTeamDto>>.Success(200, dataDto);
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetAllWithDetails(int id)
        {
            var data = await _teamMemberRepository.GetAllWithDetails(id).ToListAsync();
            var dataDto = _mapper.Map<IEnumerable<AppUserWithTeamDto>>(data);

            return CustomResponseDto<IEnumerable<AppUserWithTeamDto>>.Success(200, dataDto);
        }

        public async Task<CustomResponseDto<AppUserWithTeamDto>> GetSingleWithDetailsAsync(int id)
        {
            var data = await _teamMemberRepository.GetSingleWithDetailsAsync(id);
            var dataDto = _mapper.Map<AppUserWithTeamDto>(data);

            return CustomResponseDto<AppUserWithTeamDto>.Success(200, dataDto);
        }
        public async Task<TeamMember> GetByUserId(string userId)
        {
            return await _teamMemberRepository.GetByUserId(userId);
        }

        public async Task DuplicateData(int teamId, string userId, int titleId)
        {
            var data = await _teamMemberRepository.DuplicateData(teamId, userId, titleId);

            if (data)
                throw new ClientSideException("Dublicate data");
        }


    }
}
