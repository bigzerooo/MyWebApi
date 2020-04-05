using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarRepository : GenericRepository<Car, int>, ICarRepository
    {
        public CarRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
        public async Task<Car> GetCarDetailsByIdAsync(int Id)
        {
            var car = await _myDBContext.Cars
                .Include(c => c.CarType)
                .Include(c => c.CarHires)
                .Where(c=>c.Id==Id)
                .FirstOrDefaultAsync();
            return car;
        }
        public async Task<List<Car>> GetCarDetailsAsync()
        {
            var cars = await _myDBContext.Cars
                .Include(c => c.CarType)
                .Include(c => c.CarHires)
                .ToListAsync();
            return cars;
        }
    }
}
