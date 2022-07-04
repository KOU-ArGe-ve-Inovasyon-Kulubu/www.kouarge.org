using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using www.kouarge.org.Identity;

namespace www.kouarge.org.Pages.Admin
{
    public class UsersModel : PageModel
    {
        public void OnGet(UserManager<AppUser> userManager)
        {
        }
    }
}
