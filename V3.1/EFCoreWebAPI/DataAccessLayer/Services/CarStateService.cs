using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Services
{
    public class CarStateService : ICarStateService
    {
        IUnitOfWork _unitOfWork;
        public CarStateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddCarState(CarState carState)
        {
            return _unitOfWork.carStateRepository.Add(carState);
            //_sqlunitOfWork.Complete();
        }

        public void DeleteCarState(int id)
        {
            _unitOfWork.carStateRepository.Delete(id);
        }

        public IEnumerable<CarState> GetAllCarStates()
        {
            return _unitOfWork.carStateRepository.GetAll();
        }

        public CarState GetCarStateById(int Id)
        {
            return _unitOfWork.carStateRepository.Get(Id);
        }

        public void UpdateCarState(CarState carState)
        {
            _unitOfWork.carStateRepository.Update(carState);
        }
        public CarState GetCarStateDetailsById(int Id)
        {
            return _unitOfWork.carStateRepository.GetCarStateDetailsById(Id);
        }
        public List<CarState> GetCarStateDetails()
        {
            return _unitOfWork.carStateRepository.GetCarStateDetails();
        }
    }
}
