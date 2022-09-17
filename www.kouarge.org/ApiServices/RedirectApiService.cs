using KouArge.Core.DTOs;
using KouArge.Core.Models;

namespace www.kouarge.org.ApiServices
{
    public class RedirectApiService
    {
        private readonly RequestApiService _request;

        public RedirectApiService(RequestApiService requestApiService)
        {
            _request = requestApiService;
        }
        public  async Task Add(int id)
        {
           //await _request.OnlyPostAsync<CustomResponseDto<Redirect>>($"Redirect/{id}");
        }
    }
}
