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
    public class CarTypeService : ICarTypeService
    {
        IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public CarTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddCarTypeAsync(CarTypeDTO carType)
        {
            var x = _mapper.Map<CarTypeDTO, CarType>(carType);
            return await _unitOfWork.carTypeRepository.AddAsync(x);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteCarTypeAsync(int id)
        {
            await _unitOfWork.carTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CarTypeDTO>> GetAllCarTypesAsync()
        {
            var x = await _unitOfWork.carTypeRepository.GetAllAsync();
            List<CarTypeDTO> result = new List<CarTypeDTO>();
            foreach (var element in x)
                result.Add(_mapper.Map<CarType, CarTypeDTO>(element));
            return result;
        }

        public async Task<string> GetCarTypeByIdAsync(int Id)
        {
            return await _unitOfWork.carTypeRepository.GetCarTypeById(Id);            
        }

        public async Task UpdateCarTypeAsync(CarTypeDTO carType)
        {
            var x = _mapper.Map<CarTypeDTO, CarType>(carType);
            await _unitOfWork.carTypeRepository.UpdateAsync(x);
        }
        public async Task<CarType> GetCarTypeDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.carTypeRepository.GetCarTypeDetailsByIdAsync(Id);
        }
        public async Task<List<CarType>> GetCarTypeDetailsAsync()
        {
            return await _unitOfWork.carTypeRepository.GetCarTypeDetailsAsync();
        }
    }
}
