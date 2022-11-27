using KouArge.Core.DTOs;
using KouArge.Core.Services.ApiService;
using Microsoft.AspNetCore.Mvc;
using www.kouarge.org.ApiServices;
using www.kouarge.org.Dto;

namespace www.kouarge.org.Areas.Admin.Controllers
{
    [Area("admin")]

    public class HomeController : Controller
    {
        private readonly FileApiService _fileApiService;
        private readonly IEventPictureApiService _eventPictureService;

        public HomeController(FileApiService fileApiService, IEventPictureApiService eventPictureService)
        {
            _fileApiService = fileApiService;
            _eventPictureService = eventPictureService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task SendData(EventPictureDto dto, UploadFile data)
        {
            data.Path = "Event";
            var succes = await FileUpload(data);

            var list = new List<EventPictureDto>();
            foreach (var path in succes.Data)
            {
                list.Add(new EventPictureDto() { ImgUrl = path, EventId = dto.EventId, IsActive = true });
            }

            var result = await _eventPictureService.Save(list);
        }


        [HttpPost]
        public async Task<Test> FileUpload(UploadFile data)
        {
            MultipartFormDataContent form = new MultipartFormDataContent();

            //TODO: dosya yolunu ilgili controllerda ver.
            form.Add(new StringContent(data.Path), "Path");

            foreach (var file in data.files)
            {
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        form.Add(new ByteArrayContent(fileBytes, 0, fileBytes.Length), "files", $"file.jpg");
                    }
                }
            }

            return await _fileApiService.Upload(form);
        }

    }
}
