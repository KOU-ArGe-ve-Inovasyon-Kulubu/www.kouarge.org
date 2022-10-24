using KouArge.Core.DTOs;
using KouArge.Core.Services.ApiService;
using KouArge.Service.Exceptions;

namespace www.kouarge.org.ApiServices
{
    public class AccountApiService: IAccountApiService
    {
        private readonly HttpClient _httpClient;

        public AccountApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<AppUserDto> Login(AppUserLoginDto user)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Login", user);
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AppUserDto>>();

            if (!response.IsSuccessStatusCode)
            {
                return new AppUserDto() { Errors = responseBody.Errors, ErrorStatus = responseBody.ErrorStatus };
            }

            return responseBody.Data;
        }

        public async Task<AppUserDto> Register(AppUserRegisterDto newUser)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Register", newUser);
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AppUserDto>>();

            //responseBody.Errors!=null
            if (!response.IsSuccessStatusCode)
            {
                return new AppUserDto() { Errors = responseBody.Errors, ErrorStatus = responseBody.ErrorStatus };
            }

            return responseBody.Data;
        }

        public async Task<AppUserDto> RefreshTokenLogin(GetRefreshTokenDto refreshToken)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/RefreshTokenLogin", refreshToken);
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AppUserDto>>();

            if (!response.IsSuccessStatusCode)
            {
                return new AppUserDto() { Errors = responseBody.Errors, ErrorStatus = responseBody.ErrorStatus };
            }
          
            return responseBody.Data;
        }
    }
}
