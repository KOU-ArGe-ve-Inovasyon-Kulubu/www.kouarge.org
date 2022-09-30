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
        public async Task Add(int id)
        {
            //await _request.OnlyPostAsync<CustomResponseDto<Redirect>>($"Redirect/{id}");
        }

        public async Task<CustomResponseDto<List<Redirect>>> GetAllAsync()
        {
            var data = await _request.GetAsync<CustomResponseDto<List<Redirect>>>("redirect");
            return data;
        }

        public async Task<CustomResponseDto<RedirectDto>> GetByIdAsync(int id)
        {
            var data = await _request.PostAsync<CustomResponseDto<RedirectDto>>($"redirect/GetById/{id}");
            return data;
        }

        public async Task<CustomResponseDto<RedirectDto>> AddAsync(RedirectDto redirectDto)
        {
            var data = await _request.PostAsync<CustomResponseDto<RedirectDto>, RedirectDto>("redirect", redirectDto);
            return data;
        }

        public async Task<bool> UpdateAsync(RedirectDto redirectDto)
        {
            var data = await _request.PutAsync<RedirectDto>("redirect", redirectDto);
            return data;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var data = await _request.DeleteAsync($"redirect/{id}");
            return data;
        }
    }
}