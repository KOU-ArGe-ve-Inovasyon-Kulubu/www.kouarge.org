using KouArge.Core.DTOs;
using KouArge.Core.Services;
using KouArge.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedirectController : CustomBaseController
    {
        private readonly IRedirectService _redirectService;
        public RedirectController(IRedirectService service)
        {
            _redirectService = service;
        }

        [HttpPost("{text}")]
        public async Task<IActionResult> Add(string text)
        {
            var id = text.Substring(0, 16);
            await _redirectService.AddAsync(id);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }
    }
}
