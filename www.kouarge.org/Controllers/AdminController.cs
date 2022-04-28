using Microsoft.AspNetCore.Mvc;

namespace www.kouarge.org.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoleList()
        {
            return View();
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        public IActionResult Sayfa()
        {
            return View();
        }
    }
}
