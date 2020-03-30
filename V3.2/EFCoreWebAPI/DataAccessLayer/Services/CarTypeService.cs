using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class CarTypeService : ICarTypeService
    {
        IUnitOfWork _unitOfWork;
        public CarTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddCarTypeAsync(CarType carType)
        {
            return await _unitOfWork.carTypeRepository.AddAsync(carType);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteCarTypeAsync(int id)
        {
            await _unitOfWork.carTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CarType>> GetAllCarTypesAsync()
        {
            return await _unitOfWork.carTypeRepository.GetAllAsync();
        }

        public async Task<CarType> GetCarTypeByIdAsync(int Id)
        {
            return await _unitOfWork.carTypeRepository.GetAsync(Id);
        }

        public async Task UpdateCarTypeAsync(CarType carType)
        {
            await _unitOfWork.carTypeRepository.UpdateAsync(carType);
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
