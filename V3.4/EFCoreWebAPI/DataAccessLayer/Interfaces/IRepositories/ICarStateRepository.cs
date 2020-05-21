using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarStateRepository : IGenericRepository<CarState, int>
    {
        public Task<CarState> GetCarStateDetailsByIdAsync(int Id);
        public Task<List<CarState>> GetCarStateDetailsAsync();
        public Task<string> GetCarStateById(int Id);
    }
}
