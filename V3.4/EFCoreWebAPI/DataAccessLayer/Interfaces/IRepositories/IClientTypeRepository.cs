using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IClientTypeRepository : IGenericRepository<ClientType, int>
    {
        public Task<ClientType> GetClientTypeDetailsByIdAsync(int Id);
        public Task<List<ClientType>> GetClientTypeDetailsAsync();
    }
}
