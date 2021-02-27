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

        IClientTypeService _clientTypeService;
        public ClientTypeController(IClientTypeService clientTypeService) =>
            _clientTypeService = clientTypeService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _clientTypeService.GetAllClientTypesAsync());
            }
            catch
            {
                return NotFound();
            }
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _clientTypeService.GetClientTypeByIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }

        //[HttpGet("details/{id}")]
        //public async Task<IActionResult> GetDetails(int id)
        //{
        //    try
        //    {
        //        return Ok(await _clientTypeService.GetClientTypeDetailsByIdAsync(id));
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpGet("details")]
        //public async Task<IActionResult> GetDetails()
        //{
        //    try
        //    {
        //        return Ok(await _clientTypeService.GetClientTypeDetailsAsync());
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientTypeDTO clientType)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                await _clientTypeService.AddClientTypeAsync(clientType);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClientTypeDTO clientType)
        {
            try
            {
                await _clientTypeService.UpdateClientTypeAsync(clientType);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clientTypeService.DeleteClientTypeAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}