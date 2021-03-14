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
    public class CarTypeController : Controller
    {
        private readonly ICarTypeService carTypeService;

        public CarTypeController(ICarTypeService carTypeService)
        {
            this.carTypeService = carTypeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCarTypes()
        {
            var result = await carTypeService.GetAllCarTypesAsync();

            return Json(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarTypeById(int id)
        {
            var result = await carTypeService.GetCarTypeByIdAsync(id);

            return Json(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarType([FromBody] CarTypeDTO carType)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid model");

            var result = await carTypeService.AddCarTypeAsync(carType);

            return Json(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCarType([FromBody] CarTypeDTO carType)
        {
            var result = await carTypeService.UpdateCarTypeAsync(carType);

            return Json(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarType(int id)
        {
            var result = await carTypeService.DeleteCarTypeAsync(id);

            return Json(result);
        }
    }
}