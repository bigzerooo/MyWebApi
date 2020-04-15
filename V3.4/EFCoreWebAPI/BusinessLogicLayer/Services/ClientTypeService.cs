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
    public class ClientTypeService : IClientTypeService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;        
        public ClientTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddClientTypeAsync(ClientTypeDTO clientType)
        {
            var x = _mapper.Map<ClientTypeDTO, ClientType>(clientType);
            return await _unitOfWork.clientTypeRepository.AddAsync(x);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteClientTypeAsync(int Id)
        {
            await _unitOfWork.clientTypeRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<ClientTypeDTO>> GetAllClientTypesAsync()
        {
            var x = await _unitOfWork.clientTypeRepository.GetAllAsync();
            List<ClientTypeDTO> result = new List<ClientTypeDTO>();
            foreach (var element in x)
                result.Add(_mapper.Map<ClientType, ClientTypeDTO>(element));
            return result;
        }

        public async Task<ClientTypeDTO> GetClientTypeByIdAsync(int Id)
        {
            var x = await _unitOfWork.clientTypeRepository.GetAsync(Id);
            return _mapper.Map<ClientType, ClientTypeDTO>(x);
        }

        public async Task UpdateClientTypeAsync(ClientTypeDTO clientType)
        {
            var x = _mapper.Map<ClientTypeDTO, ClientType>(clientType);
            await _unitOfWork.clientTypeRepository.UpdateAsync(x);
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
