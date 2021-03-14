using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface ICarStateRepository : IGenericRepository<CarState, int>
    {
        Task<string> GetCarStateStringById(int id);
        //public Task<CarState> GetCarStateDetailsByIdAsync(int id);
        //public Task<List<CarState>> GetCarStateDetailsAsync();
    }
}