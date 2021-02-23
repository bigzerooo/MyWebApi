using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface ICarStateRepository : IGenericRepository<CarState>
    {
        public Task<CarState> GetCarStateDetailsByIdAsync(int id);
        public Task<List<CarState>> GetCarStateDetailsAsync();
        public Task<string> GetCarStateById(int id);
    }
}