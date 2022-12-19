using KouArge.Core.DTOs;

namespace KouArge.Core.Services.ApiService
{
    public interface IAccountApiService
    {
        public Task<AppUserDto> Login(AppUserLoginDto user);
        public Task<AppUserDto> Register(AppUserRegisterDto newUser);
        public Task<Token> RefreshTokenLogin(GetRefreshTokenDto refreshToken);

        public Task<CustomResponseDto<NoContentDto>> SendResetPasswordMail(ResetPasswordDto email);

    }
}
