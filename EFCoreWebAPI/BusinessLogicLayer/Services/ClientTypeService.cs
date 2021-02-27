using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ClientTypeService : BaseService, IClientTypeService
    {
        public ClientTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
        public async Task<int> AddClientTypeAsync(ClientTypeDTO clientType) =>
            await unitOfWork.ClientTypeRepository.AddAsync(mapper.Map<ClientType>(clientType));
        public async Task DeleteClientTypeAsync(int Id) =>
            await unitOfWork.ClientTypeRepository.DeleteAsync(Id);
        public async Task<IEnumerable<ClientTypeDTO>> GetAllClientTypesAsync()
        {
            var clientTypes = await unitOfWork.ClientTypeRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ClientTypeDTO>>(clientTypes);
        }
        public async Task<string> GetClientTypeByIdAsync(int Id) =>
            await unitOfWork.ClientTypeRepository.GetClientTypeStringByIdAsync(Id);
        public async Task UpdateClientTypeAsync(ClientTypeDTO clientType) =>
            await unitOfWork.ClientTypeRepository.UpdateAsync(mapper.Map<ClientType>(clientType));
        //public async Task<ClientType> GetClientTypeDetailsByIdAsync(int Id) =>
        //    await unitOfWork.ClientTypeRepository.GetClientTypeDetailsByIdAsync(Id);
        //public async Task<List<ClientType>> GetClientTypeDetailsAsync() =>
        //    await unitOfWork.ClientTypeRepository.GetClientTypeDetailsAsync();
    }
}