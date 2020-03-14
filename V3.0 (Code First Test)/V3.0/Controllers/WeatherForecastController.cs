using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using V3._0.Models;
namespace V3._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            using(var _context=new CarDBContext())
            {
                //Create
                //Car car = new Car();
                //car.Brand = "new car";
                //car.Price = 20;
                //car.PricePerHour = 20;
                //car.Type = "Легковий";
                //car.Year = 2003;
                //_context.Cars.Add(car);
                //_context.SaveChanges();

                //Update
                //Car car = _context.Cars.First(x => x.Brand == "new car");
                //car.Brand = "new car updated";
                //_context.SaveChanges();

                //Delete
                //Car car = _context.Cars.First(x => x.Brand == "new car updated");
                //_context.Cars.Remove(car);
                //_context.SaveChanges();

                //GetAll
                return _context.Cars.ToList();
            }            
        }
    }
}
