using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Attributes;

namespace WebAPI.Controllers
{
    [Analyze]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        ICarService _carService;
        public CarController(ICarService carService) => _carService = carService;

        [AllowAnonymous]
        [HttpGet("count")]
        public async Task<IActionResult> Count([FromQuery] CarParameters parameters) =>
            Ok(await _carService.GetCarCountAsync(parameters));

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] CarParameters parameters)
        {
            if (!parameters.ValidPriceRange)
                return BadRequest("Invalid price range!");
            try
            {
                PagedList<CarDTO> cars = await _carService.GetCarPagesFilteredAsync(parameters);
                if (cars != null)
                    return Ok(cars);
                return NotFound();
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
                CarDTO cars = await _carService.GetCarByIdAsync(id);
                if (cars != null)
                    return Ok(cars);
                else
                    return NotFound();
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
                return Ok(await _carService.GetCarDetailsByIdAsync(id));
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
                return Ok(await _carService.GetCarDetailsAsync());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarDTO car)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                await _carService.AddCarAsync(car);
                return StatusCode(201);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CarDTO car)
        {
            try
            {
                await _carService.UpdateCarAsync(car);
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
                await _carService.DeleteCarAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}