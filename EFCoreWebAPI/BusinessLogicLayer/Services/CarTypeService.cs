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
        public async Task<int> AddCarTypeAsync(CarTypeDTO carType) =>
            await _unitOfWork.CarTypeRepository.AddAsync(_mapper.Map<CarType>(carType));
        public async Task DeleteCarTypeAsync(int id) =>
            await _unitOfWork.CarTypeRepository.DeleteAsync(id);
        public async Task<IEnumerable<CarTypeDTO>> GetAllCarTypesAsync()
        {
            IEnumerable<CarType> carTypes = await _unitOfWork.CarTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarTypeDTO>>(carTypes);
        }
        public async Task<string> GetCarTypeByIdAsync(int Id) =>
            await _unitOfWork.CarTypeRepository.GetCarTypeById(Id);
        public async Task UpdateCarTypeAsync(CarTypeDTO carType) =>
            await _unitOfWork.CarTypeRepository.UpdateAsync(_mapper.Map<CarType>(carType));
        public async Task<CarType> GetCarTypeDetailsByIdAsync(int Id) =>
            await _unitOfWork.CarTypeRepository.GetCarTypeDetailsByIdAsync(Id);
        public async Task<List<CarType>> GetCarTypeDetailsAsync() =>
            await _unitOfWork.CarTypeRepository.GetCarTypeDetailsAsync();
    }
}