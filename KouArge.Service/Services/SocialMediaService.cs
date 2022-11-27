using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Models;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Core.UnitOfWorks;
using KouArge.Service.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace KouArge.Service.Services
{
    public class SocialMediaService : Service<SocialMedia>, ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUnitOfWork _unitOfWork;
        public SocialMediaService(IUnitOfWork unitOfWork, IGenericRepository<SocialMedia> repository, ISocialMediaRepository socialMediaRepository, IMapper mapper, ITokenHandler tokenHandler, ITeamMemberRepository teamMemberRepository) : base(unitOfWork, repository)
        {
            _socialMediaRepository = socialMediaRepository;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _teamMemberRepository = teamMemberRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task DuplicateData(int socialMediaTypeId, string token, int teamMemberId)
        {
            var decodedtoken = _tokenHandler.DecodeToken(token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            //var user = await _userManager.FindByIdAsync(userId);

            //if (user == null)
            //    throw new NotFoundException($"{typeof(AppUser).Name}({userId}) not found.");

            var data = await _socialMediaRepository.DuplicateData(socialMediaTypeId, userId, teamMemberId);

            //UserId ile TeammemberId uyuşmazsa da duplicate data hatası dondurur.....****
            if (data)
                throw new ClientSideException("Dublicate data");
        }


        //public async Task DuplicateData(int socialMediaTypeId)
        //{

        //    var data = await _socialMediaRepository.GetByIdAsync(socialMediaTypeId, userId);

        //    if (data)
        //        throw new ClientSideException("Dublicate data");
        //}

        public async Task<CustomResponseDto<IEnumerable<SocialMediaDto>>> GetAllWithDetails()
        {
            var data = await _socialMediaRepository.GetAllWithDetails().ToListAsync();
            var dataDto = _mapper.Map<IEnumerable<SocialMediaDto>>(data);
            return CustomResponseDto<IEnumerable<SocialMediaDto>>.Success(200, dataDto);
        }

        public async Task<CustomResponseDto<SocialMediaDto>> GetByIdWithDetailsAsync(int id)
        {
            var data = await _socialMediaRepository.GetByIdWithDetailsAsync(id);
            if (data == null)
                throw new NotFoundException($"{typeof(SocialMedia).Name}({id}) not found.");

            var dataDto = _mapper.Map<SocialMediaDto>(data);
            return CustomResponseDto<SocialMediaDto>.Success(200, dataDto);

        }

        public async Task<CustomResponseDto<NoContentDto>> UpdateAsync(SocialMediaUpdateDto socialMediaDto)
        {
            var decodedtoken = _tokenHandler.DecodeToken(socialMediaDto.Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            var teamMember = await _teamMemberRepository.GetByIdAsync(socialMediaDto.TeamMemberId);

            if (teamMember == null || userId != teamMember.AppUserId)
                throw new NotFoundException($"{typeof(TeamMember).Name}({socialMediaDto.TeamMemberId}) not found.");

            _socialMediaRepository.Update(_mapper.Map<SocialMedia>(socialMediaDto));

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<NoContentDto>> RemoveAsync(DeleteDto deleteDto)
        {
            var decodedtoken = _tokenHandler.DecodeToken(deleteDto.Token);
            var userId = decodedtoken.FirstOrDefault(x => x.Type == "UserId")?.Value;


            var socialMedia = await _socialMediaRepository.GetByIdAsync(deleteDto.Id);

            if (socialMedia == null)
                throw new ClientSideException("User not found.");

            var teamMember = await _teamMemberRepository.GetByUserId(userId, socialMedia.TeamMemberId);

            if (teamMember == null || socialMedia.TeamMemberId != teamMember.Id)
                throw new ClientSideException("User not found.");

            _socialMediaRepository.Remove(socialMedia);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentDto>.Success(204);

        }


    }
}
