﻿using KouArge.Core.DTOs;
using KouArge.Core.Services.ApiService;
using Microsoft.AspNetCore.Mvc;

namespace www.kouarge.org.Controllers
{

    public class FacultyController : Controller
    {
        private readonly IFacultyApiService _facultyApiService;

        public FacultyController(IFacultyApiService faultyApiService)
        {
            _facultyApiService = faultyApiService;
        }

        public async Task<IActionResult> Index()
        {
            var faculty = await _facultyApiService.GetAllAsync();
            return View(faculty);
            //return RedirectToAction("maintenance", "Home");
        }

        public async Task<IActionResult> Save()
        {
            return View();
            //return RedirectToAction("maintenance", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Save(FacultyDto facultyDto)
        {
            if (ModelState.IsValid)
            {
                await _facultyApiService.Save(facultyDto);
                return RedirectToAction(nameof(Index));
            }

            return View(facultyDto);
        }

        //[ServiceFilter(typeof(NotFoundFilter<Department>))]
        public async Task<IActionResult> Update(int id)
        {
            var faculty = await _facultyApiService.GetByIdAsync(id);

            if (faculty == null)
                return View("Error");

            return View(faculty);
            //return RedirectToAction("maintenance", "Home");


        }

        [HttpPost]
        public async Task<IActionResult> Update(FacultyDto facultyDto)
        {

            if (ModelState.IsValid)
            {
                var success = await _facultyApiService.UpdateAsync(facultyDto);

                if (success)
                    return RedirectToAction(nameof(Index));

                //hata sayfasına yonlendir
            }

            return View(facultyDto);

        }

        public async Task<IActionResult> Delete(int id)
        {
            var success = await _facultyApiService.DeleteAsync(id);

            if (success)
                return RedirectToAction(nameof(Index));
            else
                //hata sayafası
                return RedirectToAction(nameof(Index));

        }


    }
}
