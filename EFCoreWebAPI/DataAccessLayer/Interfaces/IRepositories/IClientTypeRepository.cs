using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IClientTypeRepository : IGenericRepository<ClientType>
    {
        public Task<ClientType> GetClientTypeDetailsByIdAsync(int id);
        public Task<List<ClientType>> GetClientTypeDetailsAsync();
        public Task<string> GetClientTypeByIdAsync(int id);
    }
}