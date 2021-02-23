using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Analyze]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) =>
            _roleService = roleService;

        [HttpPost]
        public async Task GiveRole([FromQuery] string id, [FromQuery] string role) =>
            await _roleService.AppointRole(id, role);

        [HttpGet("{id}")]
        public async Task<IList<string>> GetRoles(string id) =>
            await _roleService.GetAllRolesByUserId(id);

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO role)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid model");
            await _roleService.CreateRole(role);
            return Ok(role);
        }
    }
}