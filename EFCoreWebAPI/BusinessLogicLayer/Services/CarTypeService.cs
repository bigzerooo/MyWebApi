using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CarTypeService : ICarTypeService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<int> AddCarTypeAsync(CarTypeDTO carType) =>
            await _unitOfWork.CarTypeRepository.AddAsync(_mapper.Map<CarTypeDTO, CarType>(carType));
        public async Task DeleteCarTypeAsync(int id) =>
            await _unitOfWork.CarTypeRepository.DeleteAsync(id);
        public async Task<IEnumerable<CarTypeDTO>> GetAllCarTypesAsync()
        {
            IEnumerable<CarType> x = await _unitOfWork.CarTypeRepository.GetAllAsync();
            List<CarTypeDTO> result = new List<CarTypeDTO>();
            foreach (var element in x)
                result.Add(_mapper.Map<CarType, CarTypeDTO>(element));
            return result;
        }
        public async Task<string> GetCarTypeByIdAsync(int Id) =>
            await _unitOfWork.CarTypeRepository.GetCarTypeById(Id);
        public async Task UpdateCarTypeAsync(CarTypeDTO carType) =>
            await _unitOfWork.CarTypeRepository.UpdateAsync(_mapper.Map<CarTypeDTO, CarType>(carType));
        public async Task<CarType> GetCarTypeDetailsByIdAsync(int Id) =>
            await _unitOfWork.CarTypeRepository.GetCarTypeDetailsByIdAsync(Id);
        public async Task<List<CarType>> GetCarTypeDetailsAsync() =>
            await _unitOfWork.CarTypeRepository.GetCarTypeDetailsAsync();
    }
}