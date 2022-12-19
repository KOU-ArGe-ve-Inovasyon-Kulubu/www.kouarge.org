using KouArge.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Service.Services.Admin
{
    public interface IAdminAccountApiService
    {
        Task<CustomResponseDto<AppUserDto>> Login(AppUserLoginDto user);
        Task<AppUserDto> Register(AppUserRegisterDto newUser);
        Task<object> Delete(string userId);
    }
}
