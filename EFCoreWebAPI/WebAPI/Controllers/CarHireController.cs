using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Parameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    public class CarHireController : Controller
    {

        ICarHireService _carHireService;
        public CarHireController(ICarHireService carHireService)
        {
            _carHireService = carHireService;
        }

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

        // GET: api/<controller>
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    try
        //    {
        //        return Ok(await _carHireService.GetAllCarHiresAsync());
        //    }
        //    catch
        //    {
        //        return StatusCode(404);
        //    }
        //}

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _carHireService.GetCarHireByIdAsync(id));
            }
            catch
            {
                return StatusCode(404);
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
                return StatusCode(404);
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
                return StatusCode(404);
            }
        }


        // GET: api/<controller>/details/5
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
                return StatusCode(404);
            }
        }

        // GET: api/<controller>/details/
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
                return StatusCode(404);
            }
        }

        // POST api/<controller>
        [HttpPost("Hire")]
        public async Task<IActionResult> Post([FromBody]CarHireDTO value)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid model");
                var result = await _carHireService.HireCarAsync(value);
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
                return StatusCode(400);
            }
        }
        [HttpPost("Return")]
        public async Task<IActionResult> Return([FromBody]CarHireDTO value)
        {
            try
            {
                var result = await _carHireService.ReturnCarAsync(value);
                if (result == 1)
                    return Ok();
                else
                    return BadRequest();
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CarHireDTO value)
        {
            //не пашет 
            try
            {
                await _carHireService.UpdateCarHireAsync(value);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _carHireService.DeleteCarHireAsync(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }

        }
    }
}
