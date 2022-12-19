using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Repositories;
using KouArge.Core.Services;
using KouArge.Core.Services.ApiService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class AdminUserService:IAdminUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AdminUserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<IEnumerable<EventParticipantWithUserDto>>> GetAllUserEventByEventId(int eventId)
        {
            var data = await _userRepository.GetAllUserEventsWithEventIdAsync(eventId);
            return CustomResponseDto<IEnumerable<EventParticipantWithUserDto>>.Success(200, _mapper.Map<IEnumerable<EventParticipantWithUserDto>>(data));
        }
        public async Task<CustomResponseDto<IEnumerable<EventDto>>> GetUserEvent(string userId)
        {
            var data = await _userRepository.GetUserEventAttended(userId).ToListAsync();
            return CustomResponseDto<IEnumerable<EventDto>>.Success(200, _mapper.Map<IEnumerable<EventDto>>(data));
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserWithApplyDto>>> GetUserGeneralAssamblyApply(string userId)
        {
        
            var data = await _userRepository.GetUserGeneralAssamblyApply(userId).ToListAsync();
            return CustomResponseDto<IEnumerable<AppUserWithApplyDto>>.Success(200, _mapper.Map<IEnumerable<AppUserWithApplyDto>>(data));
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserWithTeamDto>>> GetUserTeam(string userId)
        {
   
            var data = await _userRepository.GetUserTeam(userId).ToListAsync();
            return CustomResponseDto<IEnumerable<AppUserWithTeamDto>>.Success(200, _mapper.Map<IEnumerable<AppUserWithTeamDto>>(data));
        }

        public async Task<CustomResponseDto<IEnumerable<SocialMediaDto>>> GetUserSocialMedias(string userId)
        {
 
            var data = await _userRepository.GetUserSocialMedias(userId).ToListAsync();

            return CustomResponseDto<IEnumerable<SocialMediaDto>>.Success(200, _mapper.Map<IEnumerable<SocialMediaDto>>(data));
        }

        public async Task<CustomResponseDto<IEnumerable<AppUserWithCertificas>>> GetUserCertificas(string userId)
        {
            //sertifica id sine gore.
 
            var data = await _userRepository.GetUserCertificas(userId).ToListAsync();

            return CustomResponseDto<IEnumerable<AppUserWithCertificas>>.Success(200, _mapper.Map<IEnumerable<AppUserWithCertificas>>(data));
        }


        public async Task<CustomResponseDto<GeneralAssemblyApplyWithUserDto>> GetUserSingleGeneralAssamblyApply(string userId,int appId)
        {

            var data = await _userRepository.GetUserSingleGeneralAssamblyApplyAsync(userId, appId);
            return CustomResponseDto<GeneralAssemblyApplyWithUserDto>.Success(200, _mapper.Map<GeneralAssemblyApplyWithUserDto>(data));
        }

        public async Task<CustomResponseDto<AppUserDto>> GetUserWithStudentNumberAsync(string studentNumber)
        {

            var data = await _userRepository.GetUserDataWithStudentNumberAsync(studentNumber);

            if(data==null)
                return CustomResponseDto<AppUserDto>.Fail(400,new ErrorViewModel() { ErrorCode="404",ErrorMessage="Kullanıcı Bulunamadı"});


            return CustomResponseDto<AppUserDto>.Success(200, _mapper.Map<AppUserDto>(data));
        }

    }
}
