using KouArge.Core.DTOs;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
  
    public class AccountController : CustomBaseController
    {
        private readonly IUserService _service;
        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> Login(AppUserLoginDto user)
        {
            return CreateActionResult(await _service.Login(user));
        }


        [HttpPost("[Action]")]
        public async Task<IActionResult> Register(AppUserRegisterDto user)
        {
            return CreateActionResult(await _service.Register(user));
        }
 
    }
}
