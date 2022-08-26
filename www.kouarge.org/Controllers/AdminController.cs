using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using www.kouarge.org.Identity;

namespace www.kouarge.org.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly AppIdentityDbContext _app1;
        public IEnumerable<IdentityRole<string>> roles { get; set; }
        public IEnumerable<AppUser> users { get; set; }
        public AdminController(AppIdentityDbContext app1)
        {
            _app1 = app1;
        }

        public IActionResult Users()
        {
            users = _app1.Users;
            return View(users);
        }

        //Sadece admin rolüne sahip kişiler bu sayfaya erişebilir 
        [Authorize(Roles = "Admin")]
        public IActionResult Roles()
        {
            roles = _app1.Roles;
            return View(roles);
        }

       
    }
}
