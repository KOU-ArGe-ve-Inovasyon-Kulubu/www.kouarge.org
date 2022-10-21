using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Core.Tokens;
using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
                Token token = _tokenHandler.CreateAccessToken(15, roles.ToList(), user.Id);
                await UpdateRefreshToken(token, user, 60);

                var data = _mapper.Map<AppUserDto>(user);
                data.Token = token;
                return CustomResponseDto<AppUserDto>.Success(200, data);

            }
            else
                return CustomResponseDto<AppUserDto>.Fail(400, "E-Mail veya şifre yanlış.", 1);
        }

        public async Task<CustomResponseDto<AppUserDto>> RefreshTokenLogin(GetRefreshTokenDto getRefreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RefreshToken == getRefreshToken.RefreshToken);

            if (user != null && user.RefreshTokenExpires > DateTime.UtcNow)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Count == 0)
                    roles = new List<string>();

                Token token = _tokenHandler.CreateAccessToken(15, roles.ToList(), user.Id);
                await UpdateRefreshToken(token, user, 60);

                var data = _mapper.Map<AppUserDto>(user);
                data.Token = token;

                return CustomResponseDto<AppUserDto>.Success(200, data);
            }
            else
                //throw new UnAuthorizedException("401");
                return CustomResponseDto<AppUserDto>.Fail(401, "UnAuthorizedException.", 1);


        }

        public async Task<CustomResponseDto<AppUserDto>> Register(AppUserRegisterDto appuserRegisterDto)
        {
            if (await _userManager.Users.FirstOrDefaultAsync(x => x.StudentNo == appuserRegisterDto.StudentNo) != null)
                return CustomResponseDto<AppUserDto>.Fail(400, $"StudentNumber({appuserRegisterDto.StudentNo}) already register.", 1);

            if (await _userManager.FindByEmailAsync(appuserRegisterDto.Email) != null)
                return CustomResponseDto<AppUserDto>.Fail(400, $"Email({appuserRegisterDto.Email}) already register.", 2);

            if (await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == appuserRegisterDto.PhoneNumber) != null)
                return CustomResponseDto<AppUserDto>.Fail(400, $"PhoneNumber({appuserRegisterDto.PhoneNumber}) already register.", 3);

            //TODO: Department kontrolu yap. Access Token ekle

            var error = new List<string>();
            appuserRegisterDto.Status = 1;

            var user = _mapper.Map<AppUser>(appuserRegisterDto);

            if (appuserRegisterDto.NotificationId)
                user.NotificationId = 1;
            else
                user.NotificationId = 4;

            user.UserName = appuserRegisterDto.StudentNo;
            IdentityResult result = await _userManager.CreateAsync(user, appuserRegisterDto.Password);

            Token token = _tokenHandler.CreateAccessToken(15, new List<string>(), user.Id);
            await UpdateRefreshToken(token, user, 60);

            var data = _mapper.Map<AppUserDto>(user);
            data.Token = token;


            if (result.Succeeded)
                return CustomResponseDto<AppUserDto>.Success(201, data);
            else
            {
                foreach (var item in result.Errors)
                {
                    error.Add(item.Description.ToString());
                }
                return CustomResponseDto<AppUserDto>.Fail(400, error);
            }
        }

        public async Task UpdateRefreshToken(Token token, AppUser user, int addRefreshTokenLifeTime)
        {
            if (user != null)
            {
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpires = token.Expiration.AddSeconds(addRefreshTokenLifeTime);
                token.RefreshTokenExpiration = token.Expiration.AddSeconds(addRefreshTokenLifeTime);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new UnAuthorizedException("401");
        }
    }
}
