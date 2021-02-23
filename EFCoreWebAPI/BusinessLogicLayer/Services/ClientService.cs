using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ClientService : BaseService, IClientService
    {
        public ClientService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> AddClientAsync(ClientDTO clientDTO)
        {
            Client client = _mapper.Map<Client>(clientDTO);
            client.ClientTypeId = 1;
            return await _unitOfWork.ClientRepository.AddAsync(client);
        }
        public async Task DeleteClientAsync(int Id) =>
            await _unitOfWork.ClientRepository.DeleteAsync(Id);
        public async Task<IEnumerable<ClientDTO>> GetAllClientsAsync()
        {
            IEnumerable<Client> clients = await _unitOfWork.ClientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientDTO>>(clients);
        }
        public async Task<ClientDTO> GetClientByIdAsync(int Id) =>
            _mapper.Map<ClientDTO>(await _unitOfWork.ClientRepository.GetAsync(Id));
        public async Task UpdateClientAsync(ClientDTO client) =>
            await _unitOfWork.ClientRepository.UpdateAsync(_mapper.Map<Client>(client));
        public async Task<Client> GetClientDetailsByIdAsync(int Id) =>
            await _unitOfWork.ClientRepository.GetClientDetailsByIdAsync(Id);
        public async Task<List<Client>> GetClientDetailsAsync() =>
            await _unitOfWork.ClientRepository.GetClientDetailsAsync();
        public async Task<PagedList<ClientDTO>> GetClientPages(ClientParameters parameters) =>
            _mapper.Map<PagedList<ClientDTO>>(await _unitOfWork.ClientRepository.GetAllPagesAsync(parameters));
    }
}