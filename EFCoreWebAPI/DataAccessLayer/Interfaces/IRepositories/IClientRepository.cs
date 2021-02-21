using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        public Task<Client> GetClientDetailsByIdAsync(int id);
        public Task<List<Client>> GetClientDetailsAsync();
        public Task<PagedList<Client>> GetAllPagesAsync(ClientParameters parameters);
    }
}