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
        public IEnumerable<Car> Get()
        {            
             return _carService.GetAllCars();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _carService.GetCarById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Car value)
        {
            _carService.AddCar(value);
        }

        // PUT api/<controller>/5
        [HttpPut/*("{id}")*/]
        public void Put([FromBody]Car value)
        {
            _carService.UpdateCar(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carService.DeleteCar(id);
        }
    }
}
