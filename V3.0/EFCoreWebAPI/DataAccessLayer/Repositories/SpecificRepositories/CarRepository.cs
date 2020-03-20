using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarRepository : GenericRepository<Car, int>, ICarRepository
    {
        public CarRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
        public Car GetCarDetailsById(int Id)
        {
            var car = _myDBContext.Cars
                .Include(c => c.CarType)
                .Include(c => c.CarHires)
                .Where(c=>c.Id==Id)
                .FirstOrDefault();
            return car;
        }
        public List<Car> GetCarDetails()
        {
            var cars = _myDBContext.Cars
                .Include(c => c.CarType)
                .Include(c => c.CarHires)
                .ToList();
            return cars;
        }
    }
}
