using DataAccessLayer.Entities;
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
    }
}
