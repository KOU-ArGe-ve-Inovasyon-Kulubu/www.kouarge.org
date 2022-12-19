using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{


    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public class AdminController : CustomBaseController
    {
        private readonly IAdminUserService _adminUserService;
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        private readonly ITeamMemberService _teamMemberService;

        public AdminController(IAdminUserService adminUserService, ISocialMediaService socialMediaService, IMapper mapper, ITeamMemberService teamMemberService)
        {
            _adminUserService = adminUserService;
            _socialMediaService = socialMediaService;
            _mapper = mapper;
            _teamMemberService = teamMemberService;
        }

        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetUsersEventAttendedWithEventId(int userId)
        {
            return CreateActionResult(await _adminUserService.GetAllUserEventByEventId(userId));
        }

        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetUserEventAttendedWithId(string userId)
        {
            return CreateActionResult(await _adminUserService.GetUserEvent(userId));
        }

        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetUserSocialWithId(string userId)
        {
            return CreateActionResult(await _adminUserService.GetUserSocialMedias(userId));
        }

        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetUserTeamWithId(string userId)
        {
            return CreateActionResult(await _adminUserService.GetUserTeam(userId));
        }

        [HttpGet("[Action]/{studentNumber}")]
        public async Task<IActionResult> GetUserWithStudentNumber(string studentNumber)
        {
            return CreateActionResult(await _adminUserService.GetUserWithStudentNumberAsync(studentNumber));
        }

        [HttpGet("[Action]/{userId}")]
        public async Task<IActionResult> GetUserApplyWithId(string userId)
        {
            return CreateActionResult(await _adminUserService.GetUserGeneralAssamblyApply(userId));
        }

        [HttpGet("[Action]/{userId}/{appId}")]
        public async Task<IActionResult> GetUserSingleApplyWithId(string userId,int appId)
        {
            return CreateActionResult(await _adminUserService.GetUserSingleGeneralAssamblyApply(userId,appId));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "TeamMember,TeamManager,Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> AddUserSocial(SocialMediaPostIdDto socialMediaDto)
        {

            await _socialMediaService.DuplicateDataId(socialMediaDto.SocaialMediaTypeId, socialMediaDto.UserId);

            var teamMember = await _teamMemberService.GetByUserId(socialMediaDto.UserId);

            if(teamMember==null)
                return CreateActionResult(CustomResponseDto<SocialMediaDto>.Fail(400, new List<ErrorViewModel>() { new ErrorViewModel() { ErrorCode="400", ErrorMessage="Kullanıcının takımı bulunamadı"} }));


            socialMediaDto.TeamMemberId = teamMember.Id;
            var socialMedia = await _socialMediaService.AddAsync(_mapper.Map<SocialMedia>(socialMediaDto));
            var socialMediaDtos = _mapper.Map<SocialMediaDto>(socialMedia);
            return CreateActionResult(CustomResponseDto<SocialMediaDto>.Success(201, socialMediaDtos));
        }
    }
}
