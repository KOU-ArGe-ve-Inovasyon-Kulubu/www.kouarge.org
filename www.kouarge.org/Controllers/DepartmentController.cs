using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services.ApiService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using www.kouarge.org.ApiServices;
using www.kouarge.org.Filters;

namespace www.kouarge.org.Controllers
{

    //[TypeFilter(typeof(UnAuthorizedFilter))]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentApiService _departmentApiService;
        private readonly IFacultyApiService _faultyApiService;
        public DepartmentController(IDepartmentApiService departmentApiService, IFacultyApiService faultyApiService)
        {
            _departmentApiService = departmentApiService;
            _faultyApiService = faultyApiService;
        }

        public async Task<IActionResult> Index()
        {
            var x = await _departmentApiService.GetDepartmentWithFacultyAsync();
            if (x.Data == null)
                return RedirectToAction("Error", "Department");

            return View(x.Data);

            //return RedirectToAction("maintenance", "Home");
        }

        public async Task<IActionResult> Save()
        {
            var faculty = await _faultyApiService.GetAllAsync();
            ViewBag.Faculty = new SelectList(faculty, "Id", "Name");
            return View();
            //return RedirectToAction("maintenance", "Home");

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

        public async Task<IActionResult> Update(IdDto<string> data)
        {
            var department = await _departmentApiService.GetByIdAsync(data);

            if (department == null)
                return View("Error");

            var faculty = await _faultyApiService.GetAllAsync();
            ViewBag.Faculty = new SelectList(faculty, "Id", "Name", department.FacultyId);
            return View(department);
            //return RedirectToAction("maintenance", "Home");

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
