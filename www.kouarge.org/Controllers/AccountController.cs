using KouArge.Core.DTOs;
using KouArge.Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using www.kouarge.org.ApiServices;
using www.kouarge.org.Models;

namespace www.kouarge.org.Controllers
{


    public class AccountController : Controller
    {
        private readonly DepartmentApiService _departmentApiService;
        private readonly AccountApiService _accountApiService;

        public AccountController(DepartmentApiService departmentApiService, AccountApiService accountApiService)
        {
            _departmentApiService = departmentApiService;
            _accountApiService = accountApiService;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto user)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountApiService.Login(user);

                if (result.Errors == null)
                {
                    HttpContext.Session.SetString("X-Access-Token", result.Token.AccessToken);
                    Response.Cookies.Append("X-Access-Token", result.Token.AccessToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.Strict,Expires=result.Token.Expiration });
                    return RedirectToAction("Index");
                }
                else
                {
                    if (result.ErrorStatus == 1)
                    {
                        ModelState.AddModelError("Email", "E-posta veya şifre hatalı.");
                        ModelState.AddModelError("Password", "E-posta veya şifre hatalı.");
                    }

                    return View(user);
                }
            }
            else
            { 
                return View(user);
            }
        }


        public async Task<IActionResult> Register()
        {
            var department = await _departmentApiService.GetDepartmentWithFacultyAsync();
            ViewBag.Department = new SelectList(department.Data, "Id", "Name");
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
                    return RedirectToAction("Index");
                }
                else
                {
                    if (result.ErrorStatus == 1)
                        ModelState.AddModelError("StudentNo", "Öğrenci numarası zaten kayıtlı.");

                    if (result.ErrorStatus == 2)
                        ModelState.AddModelError("Email", "E-posta adresi zaten kayıtlı.");

                    var department = await _departmentApiService.GetDepartmentWithFacultyAsync();
                    ViewBag.Department = new SelectList(department.Data, "Id", "Name", newUser.DepartmentId);
                    return View(newUser);
                }

            }
            else
            {
                var department = await _departmentApiService.GetDepartmentWithFacultyAsync();
                ViewBag.Department = new SelectList(department.Data, "Id", "Name", newUser.DepartmentId);
                return View(newUser);
            }

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
