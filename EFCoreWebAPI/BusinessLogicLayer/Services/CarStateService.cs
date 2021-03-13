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
    public class CarStateService : BaseService, ICarStateService
    {
        public CarStateService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IEnumerable<CarStateDTO>> GetAllCarStatesAsync()
        {
            var carStates = await unitOfWork.CarStateRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CarStateDTO>>(carStates);
        }

        public async Task<string> GetCarStateByIdAsync(int id)
        {
            return await unitOfWork.CarStateRepository.GetCarStateStringById(id);
        }

        public async Task<RequestResultDTO> AddCarStateAsync(CarStateDTO carStateDTO)
        {
            try
            {
                var carState = mapper.Map<CarState>(carStateDTO);
                await unitOfWork.CarStateRepository.AddAsync(carState);
                return new RequestResultDTO();
            }
            catch(Exception ex)
            {
                return ex.RequestResult();
            }
        }

        public async Task<RequestResultDTO> UpdateCarStateAsync(CarStateDTO carStateDTO)
        {
            try
            {
                var carState = mapper.Map<CarState>(carStateDTO);
                await unitOfWork.CarStateRepository.UpdateAsync(carState);
                return new RequestResultDTO();
            }
            catch(Exception ex)
            {
                return ex.RequestResult();
            }
            
        }

        public async Task<RequestResultDTO> DeleteCarStateAsync(int id)
        {
            try
            {
                await unitOfWork.CarStateRepository.DeleteAsync(id);
                return new RequestResultDTO();
            }
            catch (Exception ex)
            {
                return ex.RequestResult();
            }
        }
    }
}