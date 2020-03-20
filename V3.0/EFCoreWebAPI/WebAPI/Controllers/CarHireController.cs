using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IServices;
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
        public IActionResult Get()
        {
            try
            {
                return Ok(_carHireService.GetAllCarHires());
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_carHireService.GetCarHireById(id));
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // GET: api/<controller>/details/5
        [HttpGet("details/{id}")]
        public IActionResult GetDetails(int id)
        {
            try
            {
                return Ok(_carHireService.GetCarHireDetailsById(id));
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // GET: api/<controller>/details/
        [HttpGet("details")]
        public IActionResult GetDetails()
        {
            try
            {
                return Ok(_carHireService.GetCarHireDetails());
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]CarHire value)
        {
            try
            {
                _carHireService.AddCarHire(value);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(400);
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]CarHire value)
        {
            //не пашет 
            try
            {
                _carHireService.UpdateCarHire(value);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _carHireService.DeleteCarHire(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }

        }
    }
}
