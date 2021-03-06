﻿using BusinessLogicLayer.DTO;
using DataAccessLayer.Helpers;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IClientService
    {
        Task<int> AddClientAsync(ClientDTO client);
        Task UpdateClientAsync(ClientDTO client);
        Task DeleteClientAsync(int Id);
        Task<ClientDTO> GetClientByIdAsync(int Id);
        Task<IEnumerable<ClientDTO>> GetAllClientsAsync();
        //Task<Client> GetClientDetailsByIdAsync(int Id);
        //Task<List<Client>> GetClientDetailsAsync();
        Task<PagedList<ClientDTO>> GetClientPages(ClientParameters parameters);
    }
}