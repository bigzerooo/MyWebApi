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
    public class CarTypeService : BaseService, ICarTypeService
    {
        public CarTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<IEnumerable<CarTypeDTO>> GetAllCarTypesAsync()
        {
            var carTypes = await unitOfWork.CarTypeRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CarTypeDTO>>(carTypes);
        }

        public async Task<string> GetCarTypeByIdAsync(int id)
        {
            return await unitOfWork.CarTypeRepository.GetCarTypeStringById(id);
        }

        public async Task<RequestResultDTO> AddCarTypeAsync(CarTypeDTO carTypeDTO)
        {
            try
            {
                var carType = mapper.Map<CarType>(carTypeDTO);
                await unitOfWork.CarTypeRepository.AddAsync(carType);
                return new RequestResultDTO();
            }
            catch (Exception ex)
            {
                return ex.RequestResult();
            }
        }

        public async Task<RequestResultDTO> UpdateCarTypeAsync(CarTypeDTO carTypeDTO)
        {
            try
            {
                var carType = mapper.Map<CarType>(carTypeDTO);
                await unitOfWork.CarTypeRepository.UpdateAsync(carType);
                return new RequestResultDTO();
            }
            catch (Exception ex)
            {
                return ex.RequestResult();
            }
        }

        public async Task<RequestResultDTO> DeleteCarTypeAsync(int id)
        {
            try
            {
                await unitOfWork.CarTypeRepository.DeleteAsync(id);
                return new RequestResultDTO();
            }
            catch (Exception ex)
            {
                return ex.RequestResult();
            }
        }
    }
}