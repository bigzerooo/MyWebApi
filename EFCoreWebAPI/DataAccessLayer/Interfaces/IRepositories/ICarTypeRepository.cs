using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface ICarTypeRepository : IGenericRepository<CarType>
    {
        public Task<CarType> GetCarTypeDetailsByIdAsync(int id);
        public Task<List<CarType>> GetCarTypeDetailsAsync();
        public Task<string> GetCarTypeById(int id);
    }
}