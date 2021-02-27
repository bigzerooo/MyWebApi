using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IClientTypeRepository : IGenericRepository<ClientType>
    {
        Task<string> GetClientTypeStringByIdAsync(int id);
        //public Task<ClientType> GetClientTypeDetailsByIdAsync(int id);
        //public Task<List<ClientType>> GetClientTypeDetailsAsync();
    }
}