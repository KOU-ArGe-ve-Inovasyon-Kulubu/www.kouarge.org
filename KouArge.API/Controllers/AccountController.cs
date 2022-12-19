using KouArge.Core.DTOs;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    [AllowAnonymous]
    public class AccountController : CustomBaseController
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }
        [HttpPost("[Action]")]
        public async Task<IActionResult> Login(AppUserLoginDto user)
        {
            return CreateActionResult(await _service.Login(user));
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> RefreshTokenLogin(GetRefreshTokenDto getRefreshToken)
        {
            return CreateActionResult(await _service.RefreshTokenLogin(getRefreshToken));
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> PasswordReset(ResetPasswordDto data)
        {
            return CreateActionResult(await _service.ResetPassword(data));
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> PasswordResetConfirm(ResetPasswordConfirmDto data)
        {
            return CreateActionResult(await _service.ResetPasswordConfirm(data));
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> PasswordChange(ChangePasswordDto data)
        {
            return CreateActionResult(await _service.ChangePassword(data));
        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> Register(AppUserRegisterDto user)
        {
            return CreateActionResult(await _service.Register(user));
        }

        [HttpGet("[Action]/{Token}")]
        public async Task<IActionResult> DecodeToken(string Token)
        {
            return CreateActionResult(await _service.DecodeUserToken(Token));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDelete(string Token)
        {
            return CreateActionResult(await _service.SoftDeleteUser(Token));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpDelete("{Token}")]
        public async Task<IActionResult> Delete(string Token)
        {
            return CreateActionResult(await _service.DeleteUser(Token));
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpDelete("[action]/{userId}")]
        public async Task<IActionResult> DeleteWithUserId(string userId)
        {
            return CreateActionResult(await _service.DeleteUserWithId(userId));
        }

    }
}
