//using KouArge.Core.DTOs;
//using KouArge.Core.Models;
//using KouArge.Core.Services;
//using Microsoft.AspNetCore.Mvc;

//namespace www.kouarge.org.Controllers
//{
//    public class TesteController : Controller
//    {

//        private readonly IUserService _service;
//        public TesteController(IUserService service)
//        {
//            _service = service;
//        }


//        public async Task<IActionResult> Index(string user)
//        {
//            var data = await _service.GetUserEventAttended(user);
//            return View();
//        }
//    }
//}
