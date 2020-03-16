using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Services
{
    public class CarService : ICarService
    {
        IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddCar(Car car)
        {
            return _unitOfWork.carRepository.Add(car);
            //_sqlunitOfWork.Complete();
        }

        public void DeleteCar(int id)
        {
            _unitOfWork.carRepository.Delete(id);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _unitOfWork.carRepository.GetAll();
        }

        public Car GetCarById(int Id)
        {
            return _unitOfWork.carRepository.Get(Id);
        }

        public void UpdateCar(Car car)
        {
            _unitOfWork.carRepository.Update(car);
        }
    }
}
