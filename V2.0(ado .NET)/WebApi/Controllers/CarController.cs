using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{    

    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_carService.GetAllCars());
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
                return Ok(_carService.GetCarById(id));
            }
            catch
            {
                return StatusCode(404);
            }
            //return _carService.GetCarById(id);
            
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Car value)
        {
            try
            {
                _carService.AddCar(value);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(400);
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut/*("{id}")*/]
        public IActionResult Put([FromBody]Car value)
        {
            try
            {
                _carService.UpdateCar(value);
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
                _carService.DeleteCar(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(404);
            }
            
        }
    }
}
