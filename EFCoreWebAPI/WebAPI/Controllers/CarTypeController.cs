using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]")]
    public class CarTypeController : Controller
    {

        ICarTypeService _carTypeService;
        public CarTypeController(ICarTypeService carTypeService) =>
            _carTypeService = carTypeService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _carTypeService.GetAllCarTypesAsync());
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
                return Ok(await _carTypeService.GetCarTypeByIdAsync(id));
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
                return Ok(await _carTypeService.GetCarTypeDetailsByIdAsync(id));
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
                return Ok(await _carTypeService.GetCarTypeDetailsAsync());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarTypeDTO carType)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                await _carTypeService.AddCarTypeAsync(carType);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarTypeDTO carType)
        {
            try
            {
                await _carTypeService.UpdateCarTypeAsync(carType);
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
                await _carTypeService.DeleteCarTypeAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}