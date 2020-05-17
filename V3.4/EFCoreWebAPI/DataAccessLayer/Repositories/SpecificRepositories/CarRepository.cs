using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.IRepositories;
using DataAccessLayer.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class CarRepository : GenericRepository<Car, int>, ICarRepository
    {
        private readonly ISortHelper<Car> _sortHelper;
        public CarRepository(MyDBContext myDBContext,ISortHelper<Car> sortHelper) : base(myDBContext)
        {
            _sortHelper = sortHelper;
        }
        public async Task<int> GetCarCountAsync(CarParameters parameters)
        {
            return await _myDBContext.Cars.CountAsync(x=>
                (x.Brand.ToLower().Contains(parameters.Brand)||string.IsNullOrWhiteSpace(parameters.Brand))
                &&x.Price<=parameters.MaxPrice
                &&x.Price>=parameters.MinPrice);
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

        public async Task<PagedList<Car>> GetAllPagesFilteredAsync(CarParameters parameters)
        {
            var cars = FindByConditionAsync(x => x.Price >= parameters.MinPrice && x.Price <= parameters.MaxPrice);//фильтрация

            SearchByBrand(ref cars, parameters.Brand);//поиск

            cars=_sortHelper.ApplySort(cars, parameters);//сортировка

            return await PagedList<Car>.ToPagedListAsync(cars, parameters.PageNumber, parameters.PageSize);//пагинация          
    }

        private void SearchByBrand(ref IQueryable<Car> cars, string brand)
        {
            if (!cars.Any() || string.IsNullOrWhiteSpace(brand))
                return;

            cars = cars.Where(x => x.Brand.ToLower().Contains(brand.Trim().ToLower()));
        }
        
    }
}
