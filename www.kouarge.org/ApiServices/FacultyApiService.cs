﻿using KouArge.Core.DTOs;
using KouArge.Service.Exceptions;
using System.Net;

namespace www.kouarge.org.ApiServices
{
    public class FacultyApiService
    {
        private readonly RequestApiService _request;

        public FacultyApiService(RequestApiService requestApiService)
        {
            _request = requestApiService;
        }

        public async Task<List<FacultyDto>> GetAllAsync()
        {
            var response = await _request.GetAsync<CustomResponseDto<List<FacultyDto>>>("faculty");
            return response.Data;
        }

        public async Task<FacultyDto> Save(FacultyDto facultyDto)
        {
            var response = await _request.PostAsync<CustomResponseDto<FacultyDto>, FacultyDto>("faculty", facultyDto);
            return response.Data;
        }

        public async Task<FacultyDto> GetByIdAsync(int id)
        {
            var response = await _request.PostAsync<CustomResponseDto<FacultyDto>> ($"faculty/{id}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(FacultyDto facultyDto)
        {
            var response = await _request.PutAsync("faculty", facultyDto);
            return response;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _request.DeleteAsync($"faculty/{id}");
            return response;
        }
    }
}
