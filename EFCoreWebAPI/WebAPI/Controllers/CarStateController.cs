using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]")]
    public class CarStateController : Controller
    {
        ICarStateService _carStateService;
        public CarStateController(ICarStateService carStateService) =>
            _carStateService = carStateService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _carStateService.GetAllCarStatesAsync());
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
                return Ok(await _carStateService.GetCarStateByIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CarStateDTO carState)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                await _carStateService.AddCarStateAsync(carState);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CarStateDTO carState)
        {
            try
            {
                await _carStateService.UpdateCarStateAsync(carState);
                return NoContent();
            }
            catch
            {
                return StatusCode(404);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _carStateService.DeleteCarStateAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }

        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                return Ok(await _carStateService.GetCarStateDetailsByIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails()
        {
            try
            {
                return Ok(await _carStateService.GetCarStateDetailsAsync());
            }
            catch
            {
                return NotFound();
            }
        }
    }
}