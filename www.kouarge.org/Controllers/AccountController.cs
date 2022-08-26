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

        public InputModel Input { get; set; }

        public AccountController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            Input = new();
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult AccesDenied()
        {
            return View();
        }

        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(Input.ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, Input.ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            Input.ReturnUrl = returnUrl;
            return View(Input);
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            Input.ReturnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Name, Input.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return LocalRedirect(Input.ReturnUrl);
                }

                ModelState.AddModelError(string.Empty, "Geçersiz giriş denemesi.");
                return View();
            }
            return View(Input);
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
            return View(Input);
        }
    }
}
