using BusinessLogicLayer.DTO.Identity;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) =>
            _roleService = roleService;

        [HttpPost]
        [Route("GiveRole")]
        public async Task GiveRole([FromQuery]string id, [FromQuery]string role) =>
            await _roleService.AppointRole(id, role);

        [HttpGet]
        [Route("GetUserRoles")]
        public async Task<IList<string>> GetRoles([FromQuery]string id) =>
            await _roleService.GetAllRolesByUserId(id);

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody]RoleDTO role)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid model");
            await _roleService.CreateRole(role);
            return Ok(role);
        }
    }
}