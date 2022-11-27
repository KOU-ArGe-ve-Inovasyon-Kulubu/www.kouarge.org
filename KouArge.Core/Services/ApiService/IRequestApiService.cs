namespace KouArge.Core.Services.ApiService
{
    public interface IRequestApiService
    {
        public Task<T> GetAsync<T>(string path);
        public Task<T> PostAsync<T, TData>(string path, TData data);
        public Task<T> PostAsync<T>(string path);
        public Task<bool> PutAsync<TData>(string path, TData data);
        public Task<bool> DeleteAsync(string path);
    }
}
