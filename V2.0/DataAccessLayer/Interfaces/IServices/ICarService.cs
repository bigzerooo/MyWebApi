using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
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
