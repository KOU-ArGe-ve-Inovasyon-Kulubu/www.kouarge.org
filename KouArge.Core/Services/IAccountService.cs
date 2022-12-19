using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace KouArge.Core.Services
{
    public interface IAccountService
    {
        public Task<CustomResponseDto<AppUserDto>> Login(AppUserLoginDto appuser);
        public Task<CustomResponseDto<AppUserDto>> Register(AppUserRegisterDto appuser);
        public Task<CustomResponseDto<Token>> RefreshTokenLogin(GetRefreshTokenDto refreshToken);
        public Task UpdateRefreshToken(Token refreshToken, AppUser user, int addRefreshTokenLifeTime);
        public Task<CustomResponseDto<NoContentDto>> ResetPassword(ResetPasswordDto email);
        public Task<CustomResponseDto<NoContentDto>> ResetPasswordConfirm(ResetPasswordConfirmDto data);
        public Task<CustomResponseDto<NoContentDto>> DeleteUser(string Token);
        public Task<CustomResponseDto<NoContentDto>> SoftDeleteUser(string Token);
        public Task<CustomResponseDto<NoContentDto>> ChangePassword(ChangePasswordDto data);
        public Task<CustomResponseDto<UserDecodeToken>> DecodeUserToken(string Token);

        public Task<CustomResponseDto<NoContentDto>> DeleteUserWithId(string userId);
    }
}
