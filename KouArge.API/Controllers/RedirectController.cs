using AutoMapper;
using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace KouArge.API.Controllers
{

    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]

    //[Route("api/[controller]")]
    [ApiController]
    public class RedirectController : CustomBaseController
    {
        private readonly IRedirectService _redirectService;
        private readonly IMapper _mapper;
        public RedirectController(IRedirectService service, IMapper mapper)
        {
            _redirectService = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Save(RedirectDto redirectDto)
        {
            return CreateActionResult(await _redirectService.AddAsync(redirectDto));
        }

        [HttpGet("{text}")]
        public async Task<IActionResult> AddCount(string text)
        {
            //TODO: Tekrar bak. hata durumu
            await _redirectService.AddCountAsync(text);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(200));
        }

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

        [HttpPut]
        public async Task<IActionResult> Update(RedirectDto redirectDto)
        {
            return CreateActionResult(await _redirectService.UpdateAsync(redirectDto));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _redirectService.DeleteAsync(id));
        }
    }
}
