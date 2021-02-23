using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarTypeService : BaseService, ICarTypeService
    {
        public CarTypeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public async Task<int> AddCarTypeAsync(CarTypeDTO carTypeDTO)
        {
            var carType = mapper.Map<CarType>(carTypeDTO);
            return await unitOfWork.CarTypeRepository.AddAsync(carType);
        }

        public async Task DeleteCarTypeAsync(int id) =>
            await unitOfWork.CarTypeRepository.DeleteAsync(id);


        public async Task<IEnumerable<CarTypeDTO>> GetAllCarTypesAsync()
        {
            var carTypes = await unitOfWork.CarTypeRepository.GetAllAsync();
            return mapper.Map<IEnumerable<CarTypeDTO>>(carTypes);
        }

        public async Task<string> GetCarTypeByIdAsync(int id) =>
            await unitOfWork.CarTypeRepository.GetCarTypeById(id);

        public async Task UpdateCarTypeAsync(CarTypeDTO carTypeDTO)
        {
            var carType = mapper.Map<CarType>(carTypeDTO);
            await unitOfWork.CarTypeRepository.UpdateAsync(carType);
        }

        public async Task<CarType> GetCarTypeDetailsByIdAsync(int id) =>
            await unitOfWork.CarTypeRepository.GetCarTypeDetailsByIdAsync(id);

        public async Task<List<CarType>> GetCarTypeDetailsAsync() =>
            await unitOfWork.CarTypeRepository.GetCarTypeDetailsAsync();
    }
}