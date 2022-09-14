using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly ITokenHandler _tokenHandler;

        public UserService(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenHandler = tokenHandler;
            _roleManager = roleManager;
        }

        public async Task<CustomResponseDto<AppUserDto>> Login(AppUserLoginDto appuser)
        {

            var user = await _userManager.FindByEmailAsync(appuser.Email);

            if (user == null)
                return CustomResponseDto<AppUserDto>.Fail(400, "E-Mail veya şifre yanlış.", 1);//boyle bir kullanıcı mevcut degil

            await _signInManager.SignOutAsync();

            //SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, appuser.Password, false);

            SignInResult result = await _signInManager.PasswordSignInAsync(user, appuser.Password, false, false);

            if (result.Succeeded)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count == 0)
                    roles = new List<string>();
                Token token = _tokenHandler.CreateAccessToken(60,roles.ToList());
                var data = _mapper.Map<AppUserDto>(user);
                data.Token = token;
                return CustomResponseDto<AppUserDto>.Success(200, data);

            }
            else
                return CustomResponseDto<AppUserDto>.Fail(400, "E-Mail veya şifre yanlış.", 1);
        }

        public async Task<CustomResponseDto<AppUserRegisterDto>> Register(AppUserRegisterDto appuserRegisterDto)
        {
            if (await _userManager.Users.FirstOrDefaultAsync(x => x.StudentNo == appuserRegisterDto.StudentNo) != null)
                return CustomResponseDto<AppUserRegisterDto>.Fail(400, $"StudentNumber({appuserRegisterDto.StudentNo}) already register.", 1);

            if (await _userManager.FindByEmailAsync(appuserRegisterDto.Email) != null)
                return CustomResponseDto<AppUserRegisterDto>.Fail(400, $"Email({appuserRegisterDto.Email}) already register.", 2);

            //TODO: Department kontrolu yap.

            var error = new List<string>();
            var user = _mapper.Map<AppUser>(appuserRegisterDto);
            user.UserName = appuserRegisterDto.Email;//TODO: Burasınu duzeltilebilir. UserName kaldır. 
            IdentityResult result = await _userManager.CreateAsync(user, appuserRegisterDto.Password);
            if (result.Succeeded)
                return CustomResponseDto<AppUserRegisterDto>.Success(201, appuserRegisterDto);
            else
            {
                foreach (var item in result.Errors)
                {
                    error.Add(item.Description.ToString());
                }
                return CustomResponseDto<AppUserRegisterDto>.Fail(400, error);
            }
        }
    }
}
