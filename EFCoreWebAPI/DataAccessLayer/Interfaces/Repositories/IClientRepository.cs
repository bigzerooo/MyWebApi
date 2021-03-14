using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces.Repositories.GenericRepositories;
using DataAccessLayer.Parameters;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.Repositories
{
    public interface IClientRepository : IGenericRepository<Client, int>
    {
        Task<PagedList<Client>> GetAllPagesAsync(ClientParameters parameters);
        //public Task<Client> GetClientDetailsByIdAsync(int id);
        //public Task<List<Client>> GetClientDetailsAsync();
    }
}