using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }



        [HttpGet("[Action]")]
        public async Task<IActionResult> GetUserEventAttended(string token)
        {
            //var decodedToken = tokenHandler.DecodeToken(token);
            //var userId = decodedToken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            return CreateActionResult(await _service.GetUserEventAttended(token));

        }


        [HttpGet]
        public async Task<IActionResult> GetUser(string token)
        {
            //var decodedToken = tokenHandler.DecodeToken(token);
            //var userId = decodedToken.FirstOrDefault(x => x.Type == "UserId")?.Value;
            return CreateActionResult(await _service.GetUserDataAsync(token));
        }


        [HttpPut]
        public async Task<IActionResult> Update(AppUserUpdateDto user)
        {
            return CreateActionResult(await _service.UpdateUser(user));
        }


        [HttpGet("[Action]")]
        public async Task<IActionResult> GetUserGeneralAssamblyApply(string token)
        {
            //var decodedToken = tokenHandler.DecodeToken(token);
            //var userId = decodedToken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            return CreateActionResult(await _service.GetUserGeneralAssamblyApply(token));

        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetUserTeam(string token)
        {
            //var decodedToken = tokenHandler.DecodeToken(token);
            //var userId = decodedToken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            return CreateActionResult(await _service.GetUserTeam(token));

        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetUserSocialMedias(string token)
        {
            //var decodedToken = tokenHandler.DecodeToken(token);
            //var userId = decodedToken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            return CreateActionResult(await _service.GetUserSocialMedias(token));

        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetUserCertificas(string token)
        {
            //var decodedToken = tokenHandler.DecodeToken(token);
            //var userId = decodedToken.FirstOrDefault(x => x.Type == "UserId")?.Value;

            return CreateActionResult(await _service.GetUserCertificas(token));

        }

    }
}
