using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ClientTypeService : IClientTypeService
    {
        IUnitOfWork _unitOfWork;
        public ClientTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddClientTypeAsync(ClientType clientType)
        {
            return await _unitOfWork.clientTypeRepository.AddAsync(clientType);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteClientTypeAsync(int Id)
        {
            await _unitOfWork.clientTypeRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<ClientType>> GetAllClientTypesAsync()
        {
            return await _unitOfWork.clientTypeRepository.GetAllAsync();
        }

        public async Task<ClientType> GetClientTypeByIdAsync(int Id)
        {
            return await _unitOfWork.clientTypeRepository.GetAsync(Id);
        }

        public async Task UpdateClientTypeAsync(ClientType clientType)
        {
           await _unitOfWork.clientTypeRepository.UpdateAsync(clientType);
        }
        public async Task<ClientType> GetClientTypeDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.clientTypeRepository.GetClientTypeDetailsByIdAsync(Id);
        }
        public async Task<List<ClientType>> GetClientTypeDetailsAsync()
        {
            return await _unitOfWork.clientTypeRepository.GetClientTypeDetailsAsync();
        }
    }
}
