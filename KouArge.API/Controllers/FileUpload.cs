using KouArge.Service.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Data;
using System.Drawing;

namespace KouArge.API.Controllers
{
    public class FileUpload : CustomBaseController
    {

        private static IWebHostEnvironment _env;
        public FileUpload(IWebHostEnvironment env)
        {
            _env = env;
        }

        public class Test
        {
            public List<string> Data { get; set; } = new List<string>();
        }
        public class UploadFile
        {
            public List<IFormFile> files { get; set; }
            public string Path { get; set; }
        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,TeamManager,TeamMember,Admin,SuperAdmin")]

        [HttpPost]
        public async Task<Test> UploadImage([FromForm] UploadFile data)
        {
            try
            {
                var path = $"/Uploads/{data.Path}/";
                var list = new Test();
                var time = "-" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string fileName;

                foreach (var file in data.files)
                {
                    fileName = Path.Combine(Guid.NewGuid() + time + ".jpg");

                    if (file.Length > 0)
                    {
                        if (!Directory.Exists(_env.WebRootPath + path))
                        {
                            Directory.CreateDirectory(_env.WebRootPath + path);
                        }

                        using (FileStream fileStream = System.IO.File.Create(_env.WebRootPath + path + fileName))
                        {
                            file.CopyTo(fileStream);
                            fileStream.Flush();
                            list.Data.Add(path + fileName);
                        }
                    }
                }

                return list;

            }
            catch
            {

                throw new ClientSideException("FileUpload");
            }


        }


        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Manager,TeamManager,TeamMember,Admin,SuperAdmin")]

        [HttpGet("[Action]")]
        public FileContentResult Qr()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("Test", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(15);


            var bitmap = Convert(qrCodeImage);

            //using (var ms = new MemoryStream(bitmap))
            //{
            //     var s= System.Drawing.Image.FromStream(ms);
            //}


            return File(bitmap, "image/png");
        }
        private byte[] Convert(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        //[HttpGet]
        //public byte[] ShowImage(string imagePath)
        //{

        //    string filePath = _env.WebRootPath + "/Upload/" + imagePath;
        //    using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
        //    {
        //        using (var memoryStream = new MemoryStream())
        //        {
        //            fileStream.CopyTo(memoryStream);

        //            byte[] byteImage = memoryStream.ToArray();
        //            return byteImage;
        //        }
        //    }
        //}
    }
}