using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Analyze]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]")]
    public class ClientTypeController : Controller
    {
        private readonly IClientTypeService clientTypeService;

        public ClientTypeController(IClientTypeService clientTypeService)
        {
            this.clientTypeService = clientTypeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetClientTypes()
        {
            var result = await clientTypeService.GetAllClientTypesAsync();

            return Json(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientTypeById(int id)
        {
            var result = await clientTypeService.GetClientTypeByIdAsync(id);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddClientType([FromBody] ClientTypeDTO clientType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model");
            }

            var result = await clientTypeService.AddClientTypeAsync(clientType);

            return Json(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClientType([FromBody] ClientTypeDTO clientType)
        {
            var result = await clientTypeService.UpdateClientTypeAsync(clientType);

            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await clientTypeService.DeleteClientTypeAsync(id);

            return Json(result);
        }
    }
}