using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using www.kouarge.org.Identity;
using www.kouarge.org.Models;

namespace www.kouarge.org.Controllers
{
    //[Authorize(Roles = "admin")]
    //[Authorize]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {

            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Users()
        {
            return View(_userManager.Users);
        }

        public IActionResult RoleList()
        {
            return View(_roleManager.Roles);
        }

    }
}