    using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface ICarTypeService
    {
        int AddCarType(CarType carType);
        void UpdateCarType(CarType carType);
        void DeleteCarType(int Id);
        CarType GetCarTypeById(int Id);
        IEnumerable<CarType> GetAllCarTypes();
        CarType GetCarTypeDetailsById(int Id);
        List<CarType> GetCarTypeDetails();
    }
}
