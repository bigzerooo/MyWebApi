using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using DataAccessLayer.DBContext;
using BusinessLogicLayer.Interfaces.IServices;
using BusinessLogicLayer.DTO;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    [Route("api/[controller]")]
    public class CarTypeController : Controller
    {

        ICarTypeService _carTypeService;
        public CarTypeController(ICarTypeService carTypeService)
        {
            _carTypeService = carTypeService;
        }


        // GET: api/<controller>
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
                return StatusCode(404);
            }
        }

        // GET api/<controller>/5
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
                return StatusCode(404);
            }
        }

        // GET: api/<controller>/details/5
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                return Ok(await _carTypeService.GetCarTypeDetailsByIdAsync(id));
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
                return Ok(await _carTypeService.GetCarTypeDetailsAsync());
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CarTypeDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                await _carTypeService.AddCarTypeAsync(value);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CarTypeDTO value)
        {
            //не пашет 
            try
            {
                await _carTypeService.UpdateCarTypeAsync(value);
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
                await _carTypeService.DeleteCarTypeAsync(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }

        }
    }
}
