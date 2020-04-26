using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Parameters;
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

        public async Task<PagedList<Car>> GetAllPagesFilteredAsync(CarParameters parameters)//фильтрация, поиск, пагинация и сортировка
        {
            var cars = FindByConditionAsync(x => x.Price >= parameters.MinPrice && x.Price <= parameters.MaxPrice);

            SearchByBrand(ref cars, parameters.Brand);

            return await PagedList<Car>.ToPagedListAsync(cars, parameters.PageNumber, parameters.PageSize);            
        }
        private void SearchByBrand(ref IQueryable<Car> cars, string brand)
        {
            if (!cars.Any() || string.IsNullOrWhiteSpace(brand))
                return;

            cars = cars.Where(x => x.Brand.ToLower().Contains(brand.Trim().ToLower()));
        }
    }
}
