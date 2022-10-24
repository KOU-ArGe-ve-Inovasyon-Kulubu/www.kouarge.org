using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IAccountApiService
    {
        public Task<AppUserDto> Login(AppUserLoginDto user);
        public Task<AppUserDto> Register(AppUserRegisterDto newUser);
        public Task<AppUserDto> RefreshTokenLogin(GetRefreshTokenDto refreshToken);

    }
}
