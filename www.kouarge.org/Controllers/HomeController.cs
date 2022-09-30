using Microsoft.AspNetCore.Mvc;

namespace www.kouarge.org.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/{test}")]
        public IActionResult Test()
        {
            return RedirectToAction("index");
        }
    }
}
