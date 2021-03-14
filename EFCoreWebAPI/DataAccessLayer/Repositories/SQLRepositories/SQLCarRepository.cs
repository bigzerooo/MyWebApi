using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.Helpers;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Parameters;
using DataAccessLayer.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLCarRepository : SQLGenericRepository<Car, int>, ICarRepository
    {
        private readonly ISortHelper<Car> sortHelper;

        public SQLCarRepository(SQLDbContext myDBContext, ISortHelper<Car> sortHelper) : base(myDBContext)
        {
            this.sortHelper = sortHelper;
        }

        public async Task<int> GetCarCountAsync(CarParameters parameters)
        {
            return await _dbSet
                .CountAsync(c =>
                    (c.Brand.ToLower().Contains(parameters.Brand) || string.IsNullOrWhiteSpace(parameters.Brand))
                    && c.Price <= parameters.MaxPrice && c.Price >= parameters.MinPrice);
        }

        public async Task<PagedList<Car>> GetAllPagesFilteredAsync(CarParameters parameters)
        {
            IQueryable<Car> cars = FindByConditionAsync(c => c.Price >= parameters.MinPrice && c.Price <= parameters.MaxPrice);
            SearchByBrand(ref cars, parameters.Brand);
            cars = sortHelper.ApplySort(cars, parameters);
            return await PagedList<Car>.ToPagedListAsync(cars, parameters.PageNumber, parameters.PageSize);
        }

        //закрыто на доработку
        //public async Task<Car> GetCarDetailsByIdAsync(int Id) =>
        //    await _myDBContext.Cars
        //        .Include(c => c.CarType)
        //        .Include(c => c.CarHires)
        //        .Where(c => c.Id == Id)
        //        .FirstOrDefaultAsync();
        //public async Task<List<Car>> GetCarDetailsAsync() => await _myDBContext.Cars
        //        .Include(c => c.CarType)
        //        .Include(c => c.CarHires)
        //        .ToListAsync();

        private void SearchByBrand(ref IQueryable<Car> cars, string brand)
        {
            if (!cars.Any() || string.IsNullOrWhiteSpace(brand))
                return;
            cars = cars.Where(x => x.Brand.ToLower().Contains(brand.Trim().ToLower()));
        }
    }
}