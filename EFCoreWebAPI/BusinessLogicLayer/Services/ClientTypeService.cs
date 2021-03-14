using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.DTO.Results;
using BusinessLogicLayer.Extensions;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class ClientTypeService : BaseService, IClientTypeService
    {
        public ClientTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IEnumerable<ClientTypeDTO>> GetAllClientTypesAsync()
        {
            var clientTypes = await unitOfWork.ClientTypeRepository.GetAllAsync();
            return mapper.Map<IEnumerable<ClientTypeDTO>>(clientTypes);
        }

        public async Task<string> GetClientTypeByIdAsync(int Id)
        {
            return await unitOfWork.ClientTypeRepository.GetClientTypeStringByIdAsync(Id);
        }

        public async Task<RequestResultDTO> AddClientTypeAsync(ClientTypeDTO clientTypeDTO)
        {
            try
            {
                var clientType = mapper.Map<ClientType>(clientTypeDTO);
                await unitOfWork.ClientTypeRepository.AddAsync(clientType);
                return new RequestResultDTO();
            }
            catch (Exception ex)
            {
                return ex.RequestResult();
            }
        }

        public async Task<RequestResultDTO> UpdateClientTypeAsync(ClientTypeDTO clientTypeDTO)
        {
            try
            {
                var clientType = mapper.Map<ClientType>(clientTypeDTO);
                await unitOfWork.ClientTypeRepository.UpdateAsync(clientType);
                return new RequestResultDTO();
            }
            catch (Exception ex)
            {
                return ex.RequestResult();
            }
        }

        public async Task<RequestResultDTO> DeleteClientTypeAsync(int Id)
        {
            try
            {
                await unitOfWork.ClientTypeRepository.DeleteAsync(Id);
                return new RequestResultDTO();
            }
            catch (Exception ex)
            {
                return ex.RequestResult();
            }
        }
    }
}