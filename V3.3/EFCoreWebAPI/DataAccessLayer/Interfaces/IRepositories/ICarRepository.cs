using DataAccessLayer.Entities;
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
    }
}
