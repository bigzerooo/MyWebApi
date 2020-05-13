using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {

        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CarParameters parameters)
        {
            if (!parameters.ValidPriceRange)
            {
                return BadRequest("Invalid price range!");//не знаю надо ли
            }
            try
            {
                var cars = await _carService.GetCarPagesFilteredAsync(parameters);
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
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var cars = await _carService.GetCarByIdAsync(id);
                if (cars != null)
                    return Ok(await _carService.GetCarByIdAsync(id));
                else
                    return NotFound();
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // GET: api/<controller>/details/5
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                return Ok(await _carService.GetCarDetailsByIdAsync(id));
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // GET: api/<controller>/details/
        [HttpGet("details")]
        public async Task<IActionResult> GetDetails()
        {
            try
            {
                return Ok(await _carService.GetCarDetailsAsync());
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CarDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                await _carService.AddCarAsync(value);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CarDTO value)
        {
            //не пашет 
            try
            {
                await _carService.UpdateCarAsync(value);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _carService.DeleteCarAsync(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }

        }
    }
}
