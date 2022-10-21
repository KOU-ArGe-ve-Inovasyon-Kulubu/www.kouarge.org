using KouArge.Core.DTOs;
using KouArge.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using www.kouarge.org.ApiServices;
using www.kouarge.org.Models;

namespace www.kouarge.org.Controllers
{


    public class AccountController : Controller
    {
        private readonly DepartmentApiService _departmentApiService;
        private readonly FacultyApiService _facultyApiService;  
        private readonly AccountApiService _accountApiService;

        public AccountController(DepartmentApiService departmentApiService, AccountApiService accountApiService, FacultyApiService facultyApiService)
        {
            _departmentApiService = departmentApiService;
            _accountApiService = accountApiService;
            _facultyApiService = facultyApiService;
        }

        //private readonly SignInManager<AppUser> _signInManager;
        //private readonly UserManager<AppUser> _userManager;
        //public String ErrorMessage { get; set; }

        //public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //}

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult AccesDenied()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Login()
        {
            //return RedirectToAction("maintenance", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto user,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountApiService.Login(user);

                if (result.Errors == null)
                {
                    HttpContext.Session.SetString("Test", "Test");
                    Response.Cookies.Append("X-Access-Token", result.Token.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Expires = result.Token.Expiration });
                    Response.Cookies.Append("Refresh-Token", result.Token.RefreshToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Expires = result.Token.RefreshTokenExpiration });

                    if (!string.IsNullOrEmpty(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index");
                }

                if (result.ErrorStatus == 1)
                {
                    ModelState.AddModelError("Email", "E-posta veya şifre hatalı.");
                    ModelState.AddModelError("Password", "E-posta veya şifre hatalı.");
                }
                return View(user);

            }

            return View(user);
        }


        public async Task<IActionResult> Register()
        {
            var faculties = await _facultyApiService.GetAllAsync();
            ViewBag.Data = faculties;
            ViewBag.Faculty = new SelectList(faculties, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterDto newUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountApiService.Register(newUser);

                if (result.Errors == null)
                {
                    //Response.Cookies.Append("X-Access-Token", result.Token.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Expires = result.Token.Expiration });
                    //Response.Cookies.Append("Refresh-Token", result.Token.RefreshToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict, Expires = result.Token.RefreshTokenExpiration });
                    
                    return RedirectToAction("Maintenance","Home", new { data = true });
                }

                if (result.ErrorStatus == 1)
                    ModelState.AddModelError("StudentNo","Öğrenci numarası zaten kayıtlı.");

                if (result.ErrorStatus == 2)
                    ModelState.AddModelError("Email", "E-posta adresi zaten kayıtlı.");

                if (result.ErrorStatus == 3)
                    ModelState.AddModelError("PhoneNumber", "Telefon numarası zaten kayıtlı.");

                var faculty = await _facultyApiService.GetAllAsync();
                var department = await _facultyApiService.GetDepartmentByFacultyIdAsync(newUser.FacultyId);
                ViewBag.Department = new SelectList(department.Departments, "Id", "Name", newUser.FacultyId);
                ViewBag.Data = faculty;
                ViewBag.Faculty = new SelectList(faculty, "Id", "Name", newUser.DepartmentId);
                return View(newUser);
            }

            var faculties = await _facultyApiService.GetAllAsync();
            var departments = await _facultyApiService.GetDepartmentByFacultyIdAsync(newUser.FacultyId);
            ViewBag.Data = faculties;
            ViewBag.Faculty = new SelectList(faculties, "Id", "Name", newUser.DepartmentId);
            ViewBag.Department = new SelectList(departments.Departments, "Id", "Name", newUser.FacultyId);
            return View(newUser);

        }

        public async Task<JsonResult> GetDepartment(int id)
        {
            var data = await _facultyApiService.GetDepartmentByFacultyIdAsync(id);
            return Json(data.Departments.OrderBy(x => x.Name));
        }
        [Route("[Action]")]
        public async Task<IActionResult> KVKK()
        {
            return View();
        }

        //public async Task<IActionResult> Login()
        //{
        //    //if (!string.IsNullOrEmpty(ErrorMessage))
        //    //{
        //    //    ModelState.AddModelError(string.Empty, ErrorMessage);
        //    //}
        //    //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(string name, string password,string? returnUrl=null)
        //{
        //    returnUrl ??= Url.Content("~/");
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(name, password, true, lockoutOnFailure: false);
        //        if (result.Succeeded)
        //        {
        //            return LocalRedirect(returnUrl);
        //        }

        //        ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
        //        return View();
        //    }
        //    return View();
        //}

        //public IActionResult Logout()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Logout(string? returnUrl = null)
        //{
        //    await _signInManager.SignOutAsync();
        //    if (returnUrl != null)
        //    {
        //        return LocalRedirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction();
        //    }
        //}
        ////şimdilik eksik 
        //public IActionResult Register()
        //{
        //    return View();
        //}
    }
}
