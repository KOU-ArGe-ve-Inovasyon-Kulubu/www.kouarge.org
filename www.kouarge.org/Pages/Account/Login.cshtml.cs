using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using www.kouarge.org.Identity;


namespace www.kouarge.org.Pages
{
    public class LoginModel : PageModel
    {

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {

            [DataType(DataType.Text)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

        }
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        private readonly SignInManager<AppUser> _signInManager;

        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<AppUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ReturnUrl = returnUrl;
        }
        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Name, Input.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("Baþarýyla giriþ yaptýnýz.");
                    return LocalRedirect(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "Geçersiz giriþ denemesi.");
                return Page();
            }
            return Page();
        }

    }
}
