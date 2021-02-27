using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface ICarTypeRepository : IGenericRepository<CarType>
    {
        Task<string> GetCarTypeStringById(int id);
        //public Task<CarType> GetCarTypeDetailsByIdAsync(int id);
        //public Task<List<CarType>> GetCarTypeDetailsAsync();
    }
}