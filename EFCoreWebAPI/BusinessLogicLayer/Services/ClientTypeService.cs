using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ClientTypeService : BaseService, IClientTypeService
    {
        public ClientTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<int> AddClientTypeAsync(ClientTypeDTO clientType) =>
            await _unitOfWork.ClientTypeRepository.AddAsync(_mapper.Map<ClientType>(clientType));
        public async Task DeleteClientTypeAsync(int Id) =>
            await _unitOfWork.ClientTypeRepository.DeleteAsync(Id);
        public async Task<IEnumerable<ClientTypeDTO>> GetAllClientTypesAsync()
        {
            var clientTypes = await _unitOfWork.ClientTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClientTypeDTO>>(clientTypes);
        }
        public async Task<string> GetClientTypeByIdAsync(int Id) =>
            await _unitOfWork.ClientTypeRepository.GetClientTypeByIdAsync(Id);
        public async Task UpdateClientTypeAsync(ClientTypeDTO clientType) =>
            await _unitOfWork.ClientTypeRepository.UpdateAsync(_mapper.Map<ClientType>(clientType));
        public async Task<ClientType> GetClientTypeDetailsByIdAsync(int Id) =>
            await _unitOfWork.ClientTypeRepository.GetClientTypeDetailsByIdAsync(Id);
        public async Task<List<ClientType>> GetClientTypeDetailsAsync() =>
            await _unitOfWork.ClientTypeRepository.GetClientTypeDetailsAsync();
    }
}