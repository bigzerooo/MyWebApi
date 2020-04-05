﻿using BusinessLogicLayer.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces.IServices
{
    public interface IClientTypeService
    {
        Task<int> AddClientTypeAsync(ClientTypeDTO clientType);
        Task UpdateClientTypeAsync(ClientTypeDTO clientType);
        Task DeleteClientTypeAsync(int Id);
        Task<ClientTypeDTO> GetClientTypeByIdAsync(int Id);
        Task<IEnumerable<ClientTypeDTO>> GetAllClientTypesAsync();

        Task<ClientType> GetClientTypeDetailsByIdAsync(int Id);
        Task<List<ClientType>> GetClientTypeDetailsAsync();
    }
}