using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class GeneralAssemblyApplyService : Service<GeneralAssemblyApply>, IGeneralAssemblyApplyService
    {
        private readonly IGeneralAssemblyApplyRepository _generalAssemblyApplyRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeamMemberRepository _teamMemberRepository;
        public GeneralAssemblyApplyService(IUnitOfWork unitOfWork, IGenericRepository<GeneralAssemblyApply> repository, IGeneralAssemblyApplyRepository generalAssemblyApplyRepository, IMapper mapper, ITokenHandler tokenHandler, ITeamMemberRepository teamMemberRepository) : base(unitOfWork, repository)
        {
            _generalAssemblyApplyRepository = generalAssemblyApplyRepository;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _unitOfWork = unitOfWork;
            _teamMemberRepository = teamMemberRepository;
        }


        public async Task DuplicateData(int teamId, string userId, int titleId)
        {
            var data = await _generalAssemblyApplyRepository.DuplicateData(teamId, userId, titleId);

            if (data)
                throw new ClientSideException("Dublicate data");
        }

        public async Task<CustomResponseDto<GeneralAssemblyApplyDto>> GetByUserId(int id, string Token)
        {
            var decodedtoken = _tokenHandler.DecodeToken(Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            var generalAssemblyApply = _generalAssemblyApplyRepository.GetByUserId(userId, id);

            if (generalAssemblyApply == null)
                throw new ClientSideException("Notfound data");

            var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);

            return CustomResponseDto<GeneralAssemblyApplyDto>.Success(200, generalAssemblyApplyDto);

        }

        public async Task<CustomResponseDto<GeneralAssemblyApplyDto>> AddAsync(string token, GeneralAssemblyApply generalAssemblyApply)
        {

            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            generalAssemblyApply.AppUserId = userId;

            await _generalAssemblyApplyRepository.AddAsync(generalAssemblyApply);
            await _unitOfWork.CommitAsync();

            var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);

            return CustomResponseDto<GeneralAssemblyApplyDto>.Success(201, generalAssemblyApplyDto);
        }

        public async Task<CustomResponseDto<GeneralAssemblyApplyDto>> AddAsync(GeneralAssemblyApply generalAssemblyApply)
        {
            await _generalAssemblyApplyRepository.AddAsync(generalAssemblyApply);
            await _unitOfWork.CommitAsync();

            var generalAssemblyApplyDto = _mapper.Map<GeneralAssemblyApplyDto>(generalAssemblyApply);

            return CustomResponseDto<GeneralAssemblyApplyDto>.Success(201, generalAssemblyApplyDto);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(DeleteDto deleteDto)
        {
            var decodedtoken = _tokenHandler.DecodeToken(deleteDto.Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            var gApply = await _generalAssemblyApplyRepository.GetByIdAsync(deleteDto.Id);

            if (gApply == null || gApply.AppUserId != userId)
                throw new ClientSideException("User not found.");

            var teammember = await _teamMemberRepository.GetByGeneralAssemblyApplyId(userId, gApply.Id);

            if (teammember != null)
                _teamMemberRepository.Remove(teammember);

            //throw new ClientSideException("User not found.");

            _generalAssemblyApplyRepository.Remove(gApply);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);

        }


        public async Task<CustomResponseDto<NoContentDto>> RemoveByIdAsync(int id)
        {


            var gApply = await _generalAssemblyApplyRepository.GetByIdAsync(id);

            if (gApply == null)
                throw new ClientSideException("User not found.");

            var teammember = await _teamMemberRepository.GetByGeneralAssemblyApplyId(gApply.AppUserId, gApply.Id);

            if (teammember != null)
                _teamMemberRepository.Remove(teammember);

            _generalAssemblyApplyRepository.Remove(gApply);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);

        }


        public async Task<CustomResponseDto<IEnumerable<GeneralAssemblyApplyWithUserDto>>> GetAllWithUserAsync()
        {
            var generalAssemblyApply = await _generalAssemblyApplyRepository.GetAllWithUser().ToListAsync();
            var generalAssemblyApplyDto = _mapper.Map<List<GeneralAssemblyApplyWithUserDto>>(generalAssemblyApply);

            return CustomResponseDto<IEnumerable<GeneralAssemblyApplyWithUserDto>>.Success(200, generalAssemblyApplyDto);

        }
    }
}
