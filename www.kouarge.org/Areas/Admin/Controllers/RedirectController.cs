using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using KouArge.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using www.kouarge.org.ApiServices;

namespace www.kouarge.org.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RedirectController : Controller
    {
        private RedirectApiService _redirectApiService;

        public RedirectController(RedirectApiService redirectService)
        {
            _redirectApiService = redirectService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _redirectApiService.GetAllAsync();
            return View(data.Data);
        }

        public async Task<IActionResult> Save()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(RedirectDto redirectDto)
        {
            if (ModelState.IsValid)
            {
                //TODO: Id kontrolü yap
                var data = await _redirectApiService.AddAsync(redirectDto);
                if(data.ErrorStatus==1)
                {
                    ModelState.AddModelError("Name", $"Name({redirectDto.Name}) zaten mevcut.");
                    return View(redirectDto);

                }
                return RedirectToAction(nameof(Index));
            }

            return View(redirectDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await _redirectApiService.GetByIdAsync(id);

            //TODO:ToastJs veya AlertifyJs ekle
            if (data == null)
                return View("Error");

            return View(data.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RedirectDto redirectDto)
        {
            if (ModelState.IsValid)
            {
                var success = await _redirectApiService.UpdateAsync(redirectDto);

                //TODO: Id kontrolü yap
                if (success)
                    return RedirectToAction(nameof(Index));
                else
                    return View("Error");
            }

            var redirect = await _redirectApiService.GetByIdAsync(redirectDto.Id);
            return View(redirect.Data);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var success = await _redirectApiService.DeleteAsync(id);
            if (success)
                return RedirectToAction(nameof(Index));
            else
                return View("Error");
        }

    }
}
