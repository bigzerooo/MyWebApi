using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface ICarService
    {
        int AddCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int Id);
        Car GetCarById(int Id);
        IEnumerable<Car> GetAllCars();
    }
}
