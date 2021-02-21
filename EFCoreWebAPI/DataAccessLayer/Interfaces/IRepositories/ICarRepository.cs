using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        public Task<Car> GetCarDetailsByIdAsync(int id);
        public Task<List<Car>> GetCarDetailsAsync();
        public Task<PagedList<Car>> GetAllPagesFilteredAsync(CarParameters parameters);
        public Task<int> GetCarCountAsync(CarParameters parameters);
    }
}