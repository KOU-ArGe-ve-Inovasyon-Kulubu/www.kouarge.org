using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using www.kouarge.org.Identity;
using www.kouarge.org.Models;

namespace www.kouarge.org.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppIdentityDbContext _appIdentityDbContext;

        public HomeController(ILogger<HomeController> logger, AppIdentityDbContext dbContext)
        {
            _appIdentityDbContext = dbContext;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var roles = _appIdentityDbContext.Roles.FirstOrDefault();

            return View(roles);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
