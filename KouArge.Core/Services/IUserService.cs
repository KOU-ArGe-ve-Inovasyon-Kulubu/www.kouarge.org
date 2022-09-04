using KouArge.Core.DTOs;
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
       public Task<CustomResponseDto<AppUserRegisterDto>> Register(AppUserRegisterDto appuser);

    }
}
