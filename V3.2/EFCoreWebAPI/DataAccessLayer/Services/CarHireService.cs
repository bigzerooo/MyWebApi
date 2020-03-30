using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public class CarHireService : ICarHireService
    {
        IUnitOfWork _unitOfWork;
        public CarHireService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddCarHireAsync(CarHire carHire)
        {
            return await _unitOfWork.carHireRepository.AddAsync(carHire);
            //_sqlunitOfWork.Complete();
        }

        public async Task DeleteCarHireAsync(int Id)
        {
            await _unitOfWork.carHireRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<CarHire>> GetAllCarHiresAsync()
        {
            return await _unitOfWork.carHireRepository.GetAllAsync();
        }

        public async Task<CarHire> GetCarHireByIdAsync(int Id)
        {
            return await _unitOfWork.carHireRepository.GetAsync(Id);
        }

        public async Task UpdateCarHireAsync(CarHire carHire)
        {
            await _unitOfWork.carHireRepository.UpdateAsync(carHire);
        }
        public async Task<CarHire> GetCarHireDetailsByIdAsync(int Id)
        {
            return await _unitOfWork.carHireRepository.GetCarHireDetailsByIdAsync(Id);
        }
        public async Task<List<CarHire>> GetCarHireDetailsAsync()
        {
            return await _unitOfWork.carHireRepository.GetCarHireDetailsAsync();
        }
    }
}
