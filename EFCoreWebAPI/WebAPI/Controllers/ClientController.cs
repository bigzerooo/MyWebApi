using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Analyze]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        IClientService _clientService;
        public ClientController(IClientService clientService) =>
            _clientService = clientService;

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ClientParameters parameters)
        {
            try
            {
                return Ok(await _clientService.GetClientPages(parameters));
            }
            catch
            {
                return NotFound();
            }
        }

        //[Authorize(Roles = "admin")]
        //[HttpGet("details/{id}")]
        //public async Task<IActionResult> GetDetails(int id)
        //{
        //    try
        //    {
        //        return Ok(await _clientService.GetClientDetailsByIdAsync(id));
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}

        //[Authorize(Roles = "admin")]
        //[HttpGet("details")]
        //public async Task<IActionResult> GetDetails()
        //{
        //    try
        //    {
        //        return Ok(await _clientService.GetClientDetailsAsync());
        //    }
        //    catch
        //    {
        //        return NotFound();
        //    }
        //}

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _clientService.GetClientByIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientDTO client)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                var id = await _clientService.AddClientAsync(client);
                return Ok(id);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClientDTO client)
        {
            try
            {
                await _clientService.UpdateClientAsync(client);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clientService.DeleteClientAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}