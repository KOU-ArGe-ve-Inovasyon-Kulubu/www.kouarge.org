using Microsoft.AspNetCore.Mvc;

namespace www.kouarge.org.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            //return RedirectToAction("Register", "Account");
            return View();
        }

        //[Route("{text}")]
        //public IActionResult MaintenanceRedirect(bool data = false)
        //{
        //    ViewBag.Succes = data;
        //    return View("Maintenance");
        //}

        //[Route("Home/{text}")]
        //public IActionResult Maintenance(bool data=false)
        //{
        //    ViewBag.Succes = data;
        //    return View();
        //}
    }
}
