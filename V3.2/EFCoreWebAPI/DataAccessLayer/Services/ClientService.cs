using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class ClientService : IClientService
    {
        IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddClientAsync(Client client)
        {
            return await _unitOfWork.clientRepository.AddAsync(client);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteClientAsync(int Id)
        {
            await _unitOfWork.clientRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _unitOfWork.clientRepository.GetAllAsync();
        }

        public async Task<Client> GetClientByIdAsync(int Id)
        {
            return await _unitOfWork.clientRepository.GetAsync(Id);
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _unitOfWork.clientRepository.UpdateAsync(client);
        }

        public async Task<Client> GetClientDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.clientRepository.GetClientDetailsByIdAsync(Id);
        }
        public async Task<List<Client>> GetClientDetailsAsync()
        {
            return await _unitOfWork.clientRepository.GetClientDetailsAsync();
        }
    }
}
