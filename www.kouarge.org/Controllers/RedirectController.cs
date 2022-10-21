using KouArge.Core.Services;
using KouArge.Service.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using www.kouarge.org.ApiServices;

namespace www.kouarge.org.Controllers
{
    public class RedirectController : Controller
    {

        private readonly IRedirectService _redirectService;
        public RedirectController(IRedirectService service)
        {
            _redirectService = service;
        }

        //[Route("R/[Action]")]
        //public async Task<IActionResult> QR1()
        //{
        //    await _redirectService.AddAsync("1");
        //    return Redirect("https://www.twitch.tv/directory/all");
        //    //ViewBag.Url = "https://www.twitch.tv/directory/all";
        //    //return View("QR");
        //}

        [Route("R/{text}")]
        public async Task<IActionResult> CustomRedirect(string text)
        {
            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;

            var url = await _redirectService.AddCountAsync(text);

            //TODO: pasive duruma sayfa yap. yonlendir.
            if (url == null)
                return RedirectToAction("Error", "Department");

            return Redirect(url);
        
        }

        [Route("[Action]")]
        public async Task<IActionResult> TeknikTakimBrosur(string text)
        {
            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;
            text = "tekniktakimbrosur";
            var url = await _redirectService.AddCountAsync(text);

            //TODO: pasive duruma sayfa yap. yonlendir.
            if (url == null)
                return RedirectToAction("Error", "Department");

            return Redirect(url);

        }
    }
}
