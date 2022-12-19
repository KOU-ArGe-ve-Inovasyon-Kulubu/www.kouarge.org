using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.DTOs.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KouArge.Core.Services.ApiService
{
    public interface IUserApiService
    {
        Task<AppUserDto> GetUser(string token);
        Task<CustomResponseDto<IEnumerable<AppUserDto>>> GetAllUser();
        Task<AppUserDto> GetUserById(string userId);
        Task<CustomResponseDto<NoContentDto>> UpdateUserWithId(AppUserUpdateViewModel userUpdateDto);

    }
}
