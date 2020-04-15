using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarHireController : Controller
    {

        ICarHireService _carHireService;
        public CarHireController(ICarHireService carHireService)
        {
            _carHireService = carHireService;
        }


        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _carHireService.GetAllCarHiresAsync());
            }
            catch
            {
                return StatusCode(404);
            }
        }

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

        // GET: api/<controller>/details/5
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CarHireDTO value)
        {
            try
            {
                await _carHireService.AddCarHireAsync(value);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<controller>/5
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
