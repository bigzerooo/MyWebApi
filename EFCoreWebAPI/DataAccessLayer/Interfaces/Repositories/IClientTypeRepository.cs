using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IClientTypeRepository : IGenericRepository<ClientType>
    {
        public Task<ClientType> GetClientTypeDetailsByIdAsync(int id);
        public Task<List<ClientType>> GetClientTypeDetailsAsync();
        public Task<string> GetClientTypeByIdAsync(int id);
    }
}