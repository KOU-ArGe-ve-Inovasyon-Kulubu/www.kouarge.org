using KouArge.Core.DTOs;
using KouArge.Core.DTOs.UpdateDto;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

    //[Route("api/[controller]")]
    [ApiController]
    public class RedirectController : CustomBaseController
    {
        private readonly IRedirectService _redirectService;
        public RedirectController(IRedirectService service)
        {
            _redirectService = service;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost]
        public async Task<IActionResult> Save(RedirectDto redirectDto)
        {
            return CreateActionResult(await _redirectService.AddAsync(redirectDto));
        }
        [AllowAnonymous]
        [HttpGet("{text}")]
        public async Task<IActionResult> AddCount(string text)
        {
            //TODO: Tekrar bak. hata durumu
            var url = await _redirectService.AddCountAsync(text);
            return CreateActionResult(CustomResponseDto<string>.Success(200, url));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "ReadOnly,Admin,SuperAdmin")]

        [HttpGet]
        public async Task<IActionResult> GettAllAsync()
        {
            return CreateActionResult(await _redirectService.GetAllAsync());
        }


        //[HttpPost("[Action]/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    return CreateActionResult(await _redirectService.GetByIdAsync(id));

        //}

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPut]
        public async Task<IActionResult> Update(RedirectUpdateDto redirectDto)
        {
            return CreateActionResult(await _redirectService.UpdateAsync(redirectDto));

        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpPost("[Action]")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            return CreateActionResult(await _redirectService.SoftDelete(id));
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,SuperAdmin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _redirectService.DeleteAsync(id));
        }

        //TODO:Soft delete
    }
}
