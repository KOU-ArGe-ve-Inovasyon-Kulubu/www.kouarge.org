﻿using KouArge.Core.DTOs;
using KouArge.Service.Exceptions;

namespace www.kouarge.org.ApiServices
{
    public class AccountApiService
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

        public async Task<AppUserRegisterDto> Register(AppUserRegisterDto newUser)
        {
            var response = await _httpClient.PostAsJsonAsync("Account/Register", newUser);
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<AppUserRegisterDto>>();

            //responseBody.Errors!=null
            if (!response.IsSuccessStatusCode)
            {
                return new AppUserRegisterDto() { Errors = responseBody.Errors, ErrorStatus = responseBody.ErrorStatus };
            }

            return responseBody.Data;
        }
    }
}
