using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ClientService : IClientService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;        
        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddClientAsync(ClientDTO client)
        {
            var x = _mapper.Map<ClientDTO, Client>(client);
            return await _unitOfWork.clientRepository.AddAsync(x);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteClientAsync(int Id)
        {
            await _unitOfWork.clientRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClientsAsync()
        {
            var x = await _unitOfWork.clientRepository.GetAllAsync();
            List<ClientDTO> result = new List<ClientDTO>();
            foreach (var element in x)
                result.Add(_mapper.Map<Client, ClientDTO>(element));
            return result;
        }

        public async Task<ClientDTO> GetClientByIdAsync(int Id)
        {
            var x = await _unitOfWork.clientRepository.GetAsync(Id);
            return _mapper.Map<Client,ClientDTO>(x);
        }

        public async Task UpdateClientAsync(ClientDTO client)
        {
            var x = _mapper.Map<ClientDTO, Client>(client);
            await _unitOfWork.clientRepository.UpdateAsync(x);
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
