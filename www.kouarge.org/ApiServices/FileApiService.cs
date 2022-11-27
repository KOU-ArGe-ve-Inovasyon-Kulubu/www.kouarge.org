using Microsoft.AspNetCore.Mvc;
using www.kouarge.org.Dto;

namespace www.kouarge.org.ApiServices
{
    public class FileApiService
    {
        private readonly HttpClient _httpClient;

        public FileApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



        [NonAction]
        public async Task<Test> Upload(HttpContent data)
        {

            var response = await _httpClient.PostAsync("FileUpload", data);
            var res = await response.Content.ReadFromJsonAsync<Test>();
            return res;
        }

    }
}
