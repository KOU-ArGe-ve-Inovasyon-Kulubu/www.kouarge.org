using KouArge.Core.DTOs;
using KouArge.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using www.kouarge.org.ApiServices;
using www.kouarge.org.Filters;

namespace www.kouarge.org.Controllers
{

    //[TypeFilter(typeof(UnAuthorizedFilter))]
    public class DepartmentController : Controller
    {
        private readonly DepartmentApiService _departmentApiService;
        private readonly FacultyApiService _faultyApiService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DepartmentController(DepartmentApiService departmentApiService, FacultyApiService faultyApiService, IHttpContextAccessor httpContextAccessor)
        {
            _departmentApiService = departmentApiService;
            _faultyApiService = faultyApiService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            //string token = _httpContextAccessor.HttpContext.Request.Cookies["X-Access-Token"];
            var x = await _departmentApiService.GetDepartmentWithFacultyAsync();
            if (x.Data == null)
                return RedirectToAction("Error", "Department");

            return View(x.Data);
        }

        public async Task<IActionResult> Save()
        {
            var faculty = await _faultyApiService.GetAllAsync();
            ViewBag.Faculty = new SelectList(faculty, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(DepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                await _departmentApiService.Save(departmentDto);
                return RedirectToAction(nameof(Index));
            }

            var faculty = await _faultyApiService.GetAllAsync();
            ViewBag.Faculty = new SelectList(faculty, "Id", "Name", departmentDto.FacultyId);
            return View(departmentDto);
        }

        public async Task<IActionResult> Update(int id)
        {
            var department = await _departmentApiService.GetByIdAsync(id);

            if (department == null)
                return View("Error");

            var faculty = await _faultyApiService.GetAllAsync();
            ViewBag.Faculty = new SelectList(faculty, "Id", "Name", department.FacultyId);
            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Update(DepartmentDto departmentDto)
        {

            if (ModelState.IsValid)
            {
               var success = await _departmentApiService.UpdateAsync(departmentDto);
                if (success)
                    return RedirectToAction(nameof(Index));

            }

            var faculty = await _faultyApiService.GetAllAsync();
            ViewBag.Faculty = new SelectList(faculty, "Id", "Name", departmentDto.FacultyId);

            return View(departmentDto);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var success = await _departmentApiService.DeleteAsync(id);

            if (success)
                return RedirectToAction(nameof(Index));
            else
                //hata sayafasına yonlendir
                return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }

        public IActionResult Forbidden(ErrorViewModel errorViewModel)
        {
            return View(errorViewModel);
        }

    }
}
