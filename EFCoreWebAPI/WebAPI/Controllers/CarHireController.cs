using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class CarHireController : Controller
    {
        ICarHireService _carHireService;
        public CarHireController(ICarHireService carHireService) =>
            _carHireService = carHireService;

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CarHireParameters parameters)
        {
            try
            {
                return Ok(await _carHireService.GetCarHirePages(parameters));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _carHireService.GetCarHireByIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("client/{id}")]
        public async Task<IActionResult> GetByClientId(int id)
        {
            try
            {
                return Ok(await _carHireService.GetCarHiresByClientIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("Unreturned/{id}")]
        public async Task<IActionResult> GetUnreturnedByClientId(int id)
        {
            try
            {
                return Ok(await _carHireService.GetUnreturnedCarHiresByClientIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                return Ok(await _carHireService.GetCarHireDetailsByIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpGet("details")]
        public async Task<IActionResult> GetDetails()
        {
            try
            {
                return Ok(await _carHireService.GetCarHireDetailsAsync());
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("Hire")]
        public async Task<IActionResult> Post([FromBody]CarHireDTO carHire)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                int result = await _carHireService.HireCarAsync(carHire);
                switch (result)
                {
                    case 0: return BadRequest();
                    case -1: return BadRequest("Car not found");
                    case -2: return BadRequest("Client not found");
                    case -3: return BadRequest("Wrong time");
                    default: return Ok(result);
                }
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("Return")]
        public async Task<IActionResult> Return([FromBody]CarHireDTO value)
        {
            try
            {
                int result = await _carHireService.ReturnCarAsync(value);
                if (result == 1)
                    return Ok();
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CarHireDTO value)
        {
            try
            {
                await _carHireService.UpdateCarHireAsync(value);
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
                await _carHireService.DeleteCarHireAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}