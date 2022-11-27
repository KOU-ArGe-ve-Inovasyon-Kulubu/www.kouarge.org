using Microsoft.AspNetCore.Mvc;

namespace www.kouarge.org.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            // var a = await _httpClient.GetAsync("https://localhost:7038/FileUpload?imagePath=c.jpg");

            //var c = await a.Content.ReadAsByteArrayAsync();

            //var d = await GetImageAsBase64Url("a");

            return View();
        }

        public async static Task<string> GetImageAsBase64Url(string url)
        {

            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync("https://localhost:7038/FileUpload?imagePath=c.jpg");
                return "image/jpeg;base64," + Convert.ToBase64String(bytes);
            }
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
