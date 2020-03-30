using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface IClientTypeService
    {
        Task<int> AddClientTypeAsync(ClientType clientType);
        Task UpdateClientTypeAsync(ClientType clientType);
        Task DeleteClientTypeAsync(int Id);
        Task<ClientType> GetClientTypeByIdAsync(int Id);
        Task<IEnumerable<ClientType>> GetAllClientTypesAsync();
        Task<ClientType> GetClientTypeDetailsByIdAsync(int Id);
        Task<List<ClientType>> GetClientTypeDetailsAsync();
    }
}
