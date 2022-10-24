using KouArge.Core.DTOs;
using KouArge.Core.Services.ApiService;
using KouArge.Service.Exceptions;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;

namespace www.kouarge.org.ApiServices
{
    public class RequestApiService: IRequestApiService
    {
        private readonly HttpClient _httpClient;
        public RequestApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string path)
        {

            var request = _httpClient.GetAsync(path);

            if (request.Result.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnAuthorizedException("401");
            }

            if (request.Result.StatusCode == HttpStatusCode.Forbidden)
                throw new ForbiddenException("403");

            if (request.Result.StatusCode == HttpStatusCode.NotFound)
                throw new NotFoundException("404");

            if (request.Result.IsSuccessStatusCode || request.Result.StatusCode == HttpStatusCode.BadRequest)
            {
                var response = await request.Result.Content.ReadFromJsonAsync<T>();
                return response;
            }
            else
                throw new ClientSideException("400");
            //TODO: ClientSideException tekrar bak 

            #region tryCatch

            //try
            //{
            //    var response = await _httpClient.GetFromJsonAsync<T>(path);

            //    return response;
            //}
            //catch (HttpRequestException ex)
            //{
            //    //if (ex.StatusCode == HttpStatusCode.Unauthorized)
            //    //    //return new List<DepartmentWithFacultyDto>() { new DepartmentWithFacultyDto()
            //    //    //{ Errors=new List<string>() { ex.Message }, ErrorStatus=401 } };
            //    //    throw new UnAuthorizedException(ex.Message);

            //    //if (ex.StatusCode == HttpStatusCode.Forbidden)
            //    //    throw new ForbiddenException("yetki yok");

            //    return default(T);

            //}
            #endregion

        }

        public async Task<T> PostAsync<T, TData>(string path, TData data)
        {
            var response = await _httpClient.PostAsJsonAsync(path, data);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnAuthorizedException("401");

            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new ForbiddenException("403");

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new NotFoundException("404");

            if (response.IsSuccessStatusCode || response.StatusCode==HttpStatusCode.BadRequest)
            {
                var responseBody = await response.Content.ReadFromJsonAsync<T>();
                return responseBody;
            }
            throw new ClientSideException("400");


        }

        //parameter post
        public async Task<T> PostAsync<T>(string path)
        {
            var response = await _httpClient.PostAsJsonAsync(path, default(T));

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnAuthorizedException("401");

            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new ForbiddenException("403");

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new NotFoundException("404");


            if (response.IsSuccessStatusCode || response.StatusCode == HttpStatusCode.BadRequest)
            {
                //var response = await _httpClient.PostAsync(path,null);
                var responseBody = await response.Content.ReadFromJsonAsync<T>();
                return responseBody;
            }
            throw new ClientSideException("400");

        }

        //public async Task OnlyPostAsync<T>(string path)
        //{
        //    await _httpClient.PostAsJsonAsync(path, default(T));
        //}

        public async Task<bool> PutAsync<TData>(string path, TData data)
        {
            var response = await _httpClient.PutAsJsonAsync(path, data);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnAuthorizedException("401");

            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new ForbiddenException("403");

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new NotFoundException("404");


            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string path)
        {
            var response = await _httpClient.DeleteAsync(path);

             if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnAuthorizedException("401");

            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new ForbiddenException("403");

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new NotFoundException("404");

            return response.IsSuccessStatusCode;
        }
    }
}
