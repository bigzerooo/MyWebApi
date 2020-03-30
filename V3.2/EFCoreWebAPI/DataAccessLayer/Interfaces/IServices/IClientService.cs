using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface IClientService
    {
        Task<int> AddClientAsync(Client client);
        Task UpdateClientAsync(Client client);
        Task DeleteClientAsync(int Id);
        Task<Client> GetClientByIdAsync(int Id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientDetailsByIdAsync(int Id);
        Task<List<Client>> GetClientDetailsAsync();
    }
}
