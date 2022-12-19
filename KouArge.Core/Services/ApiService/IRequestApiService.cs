using KouArge.Core.DTOs;

namespace KouArge.Core.Services.ApiService
{
    public interface IRequestApiService
    {
        public Task<T> GetAsync<T>(string path);
        public Task<T> PostAsync<T, TData>(string path, TData data);
        public Task<T> PostAsync<T>(string path);
        public Task<bool> PutAsync<TData>(string path, TData data);
        public Task<bool> DeleteAsync(string path);
       public Task<T> PutAsync<T, TData>(string path, TData data);
        public Task<CustomResponseDto<T>> GetJsonAsync<T>(string path); //***

        public Task<CustomResponseDto<T>> PostJsonAsync<T, TData>(string path, TData data);
        public Task<CustomResponseDto<T>> PutJsonAsync<T>(string path, HttpContent data);
        public Task<CustomResponseDto<T>> PutJsonAsync<T, TData>(string path, TData data);
        public Task<CustomResponseDto<T>> DeleteJsonAsync<T>(string path);


    }
}
