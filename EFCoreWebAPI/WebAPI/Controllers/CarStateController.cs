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
    public class CarStateController : Controller
    {
        ICarStateService _carStateService;
        public CarStateController(ICarStateService carStateService) =>
            _carStateService = carStateService;

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCarStates()
        {
            var result = await _carStateService.GetAllCarStatesAsync();

            return Json(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarStateById(int id)
        {
            var result = await _carStateService.GetCarStateByIdAsync(id);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarState([FromBody] CarStateDTO carState)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid model");

            var result = await _carStateService.AddCarStateAsync(carState);

            return Json(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarState([FromBody] CarStateDTO carState)
        {
            var result = await _carStateService.UpdateCarStateAsync(carState);

            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarState(int id)
        {
            var result = await _carStateService.DeleteCarStateAsync(id);

            return Json(result);
        }
    }
}