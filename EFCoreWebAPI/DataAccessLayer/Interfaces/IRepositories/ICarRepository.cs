using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarRepository : IGenericRepository<Car, int>
    {
        public Task<Car> GetCarDetailsByIdAsync(int Id);
        public Task<List<Car>> GetCarDetailsAsync();
        public Task<PagedList<Car>> GetAllPagesFilteredAsync(CarParameters parameters);
        public Task<int> GetCarCountAsync(CarParameters parameters);
    }
}
