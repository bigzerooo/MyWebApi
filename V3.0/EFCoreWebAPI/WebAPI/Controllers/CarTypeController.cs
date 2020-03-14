using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using DataAccessLayer.DBContext;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CarTypeController : Controller
    {
        //это важно (депенденси инжекшн)
        private readonly MyDBContext _context;
        public CarTypeController(MyDBContext context)
        {
            _context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<CarType> Get()
        {
            using (_context)
            {
                return _context.CarTypes.ToList();
            }            
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public CarType Get(string id)
        {
            using (_context)
            {                
                return _context.CarTypes.First(t => t.Type == id);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]CarType value)
        {            
            using(_context)
            {
                _context.CarTypes.Add(value);
                _context.SaveChanges();
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]CarType value)
        {
            //не пашет 
            using (_context)
            {
                CarType x = _context.CarTypes.First(t => t.Type == id);
                x = value;
                _context.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            using (_context)
            {
                _context.CarTypes.Remove(_context.CarTypes.First(x => x.Type == id));
                _context.SaveChanges();
            }
            
        }
    }
}
