using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using www.kouarge.org.Identity;
using www.kouarge.org.Models;

namespace www.kouarge.org.Controllers
{


    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public String ErrorMessage { get; set; }

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AccesDenied()
        {
            return View();
        }

        public async Task<IActionResult> Login()
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string name, string password,string? returnUrl=null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(name, password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                return View();
            }
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout(string? returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction();
            }
        }
        //şimdilik eksik 
        public IActionResult Register()
        {
            return View();
        }
    }
}
