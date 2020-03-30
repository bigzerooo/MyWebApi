using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class CarService : ICarService
    {
        IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddCarAsync(Car car)
        {
            return await _unitOfWork.carRepository.AddAsync(car);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteCarAsync(int id)
        {
            await _unitOfWork.carRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _unitOfWork.carRepository.GetAllAsync();
        }

        public async Task<Car> GetCarByIdAsync(int Id)
        {
            return await _unitOfWork.carRepository.GetAsync(Id);
        }

        public async Task UpdateCarAsync(Car car)
        {
            await _unitOfWork.carRepository.UpdateAsync(car);
        }
        public async Task<Car> GetCarDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.carRepository.GetCarDetailsByIdAsync(Id);
        }
        public async Task<List<Car>> GetCarDetailsAsync()
        {
            return await _unitOfWork.carRepository.GetCarDetailsAsync();
        }
    }
}
