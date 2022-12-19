using KouArge.Core.DTOs;
using KouArge.Core.Models;
using KouArge.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KouArge.API.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "SuperAdmin")]
    public class RoleController : CustomBaseController
    {

        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppRoleDto role)
        {
            return CreateActionResult(await _roleService.AddRoleAsync(role));
        }

        //[HttpPost("[Action]")]
        //public async Task<IActionResult> AddRoleUser(AppRoleUserDto role)
        //{
        //    return CreateActionResult(await _roleService.AddRoleAsync(role));
        //}

        [HttpGet("[Action]/{roleName}")]
        public async Task<IActionResult> GetUsersByRoleNameAsync(string roleName)
        {
            return CreateActionResult(await _roleService.GetUsersByRoleNameAsync(roleName));
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> AssignRole(AppRoleUserDto data)
        {
            return CreateActionResult(await _roleService.AssignRoleAsync(data));
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> RemoveRoleUser(AppRoleUserDto data)
        {
            return CreateActionResult(await _roleService.RemoveRoleUserAsync(data));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _roleService.GetAllRolesAsync());
        }

        [AllowAnonymous]

        [HttpGet("[Action]/{token}")]
        public async Task<IActionResult> GetRoleUser(string token)
        {
            return CreateActionResult(await _roleService.GetRoleByUser(token));
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateAsync(string id)
        //{

        //    return CreateActionResult(await _roleService.UpdateAsync(id));
        //}


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            return CreateActionResult(await _roleService.RemoveAsync(id));
        }

        //todo role soft delete
    }
}
