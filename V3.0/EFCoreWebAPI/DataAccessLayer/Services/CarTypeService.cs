using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Services
{
    public class CarTypeService : ICarTypeService
    {
        IUnitOfWork _unitOfWork;
        public CarTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddCarType(CarType carType)
        {
            return _unitOfWork.carTypeRepository.Add(carType);
            //_sqlunitOfWork.Complete();
        }

        public void DeleteCarType(int id)
        {
            _unitOfWork.carTypeRepository.Delete(id);
        }

        public IEnumerable<CarType> GetAllCarTypes()
        {
            return _unitOfWork.carTypeRepository.GetAll();
        }

        public CarType GetCarTypeById(int Id)
        {
            return _unitOfWork.carTypeRepository.Get(Id);
        }

        public void UpdateCarType(CarType carType)
        {
            _unitOfWork.carTypeRepository.Update(carType);
        }
    }
}
