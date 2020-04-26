using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IClientRepository : IGenericRepository<Client, int>
    {
        public Task<Client> GetClientDetailsByIdAsync(int Id);
        public Task<List<Client>> GetClientDetailsAsync();
        public Task<PagedList<Client>> GetAllPagesAsync(ClientParameters parameters);
    }
}
