using KouArge.Core.DTOs;
using KouArge.Core.Models;
using Microsoft.AspNetCore.Mvc;
using www.kouarge.org.ApiServices;

namespace www.kouarge.org.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoleController : Controller
    {
        private readonly RoleApiService _roleApiService;

        public RoleController(RoleApiService roleApiService)
        {
            _roleApiService = roleApiService;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleApiService.GetRolesAsync();
            return View(roles);
        }

        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AppRoleDto appRole)
        {
            var result = await _roleApiService.AddRoleAsync(appRole);
            if (result == null)
                return View();//TODO: Hata dondur
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _roleApiService.DeleteRoleAsync(id);
            if (!result)
                return RedirectToAction("Index");//TODO: Hata dondur

            return RedirectToAction("Index");
        }


    }
}
