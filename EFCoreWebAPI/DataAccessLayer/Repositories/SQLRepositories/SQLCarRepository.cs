using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Parameters;
using DataAccessLayer.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLCarRepository : SQLGenericRepository<Car>, ICarRepository
    {
        private readonly ISortHelper<Car> _sortHelper;
        public SQLCarRepository(SQLDbContext myDBContext, ISortHelper<Car> sortHelper) : base(myDBContext) =>
            _sortHelper = sortHelper;
        public async Task<int> GetCarCountAsync(CarParameters parameters) =>
            await _myDBContext.Cars.CountAsync(x =>
                (x.Brand.ToLower().Contains(parameters.Brand) || string.IsNullOrWhiteSpace(parameters.Brand))
                && x.Price <= parameters.MaxPrice && x.Price >= parameters.MinPrice);
        public async Task<Car> GetCarDetailsByIdAsync(int Id) =>
            await _myDBContext.Cars
                .Include(c => c.CarType)
                .Include(c => c.CarHires)
                .Where(c => c.Id == Id)
                .FirstOrDefaultAsync();
        public async Task<List<Car>> GetCarDetailsAsync() => await _myDBContext.Cars
                .Include(c => c.CarType)
                .Include(c => c.CarHires)
                .ToListAsync();
        public async Task<PagedList<Car>> GetAllPagesFilteredAsync(CarParameters parameters)
        {
            IQueryable<Car> cars = FindByConditionAsync(x => x.Price >= parameters.MinPrice && x.Price <= parameters.MaxPrice);
            SearchByBrand(ref cars, parameters.Brand);
            cars = _sortHelper.ApplySort(cars, parameters);
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