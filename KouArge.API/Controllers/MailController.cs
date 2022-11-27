using KouArge.Core.DTOs;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{

    public class MailController : CustomBaseController
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> SendContactMail(ContactUsDto data)
        {
            return CreateActionResult(await _mailService.SendContactMail(data));
        }
    }
}
