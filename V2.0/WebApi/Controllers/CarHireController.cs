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
    public class CarHireController : Controller
    {
        ICarHireService _carHireService;
        public CarHireController(ICarHireService carHireService)
        {
            _carHireService = carHireService;
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<CarHire> Get()
        {
            return _carHireService.GetAllCarHires();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public CarHire Get(int id)
        {
            return _carHireService.GetCarHireById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]CarHire value)
        {
            _carHireService.AddCarHire(value);
        }

        // PUT api/<controller>/5
        [HttpPut/*("{id}")*/]
        public void Put([FromBody]CarHire value)
        {
            _carHireService.UpdateCarHire(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _carHireService.DeleteCarHire(id);
        }
    }
}
