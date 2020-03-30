using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class CarStateService : ICarStateService
    {
        IUnitOfWork _unitOfWork;
        public CarStateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddCarStateAsync(CarState carState)
        {
            return await _unitOfWork.carStateRepository.AddAsync(carState);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteCarStateAsync(int id)
        {
            await _unitOfWork.carStateRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CarState>> GetAllCarStatesAsync()
        {
            return await _unitOfWork.carStateRepository.GetAllAsync();
        }

        public async Task<CarState> GetCarStateByIdAsync(int Id)
        {
            return await _unitOfWork.carStateRepository.GetAsync(Id);
        }

        public async Task UpdateCarStateAsync(CarState carState)
        {
            await _unitOfWork.carStateRepository.UpdateAsync(carState);
        }
        public async Task<CarState> GetCarStateDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.carStateRepository.GetCarStateDetailsByIdAsync(Id);
        }
        public async Task<List<CarState>> GetCarStateDetailsAsync()
        {
            return await _unitOfWork.carStateRepository.GetCarStateDetailsAsync();
        }
    }
}
