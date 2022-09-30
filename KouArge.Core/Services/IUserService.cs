using KouArge.Core.DTOs;
using KouArge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services
{
    public interface IUserService
    {
        public Task<CustomResponseDto<AppUserDto>> Login(AppUserLoginDto appuser);
        public Task<CustomResponseDto<AppUserDto>> Register(AppUserRegisterDto appuser);

        public Task<CustomResponseDto<AppUserDto>> RefreshTokenLogin(GetRefreshTokenDto refreshToken);
        public Task UpdateRefreshToken(Token refreshToken, AppUser user,int addRefreshTokenLifeTime);

    }
}
