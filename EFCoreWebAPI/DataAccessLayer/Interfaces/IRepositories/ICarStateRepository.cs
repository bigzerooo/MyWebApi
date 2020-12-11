using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarStateRepository : IGenericRepository<CarState, int>
    {
        public Task<CarState> GetCarStateDetailsByIdAsync(int id);
        public Task<List<CarState>> GetCarStateDetailsAsync();
        public Task<string> GetCarStateById(int id);
    }
}