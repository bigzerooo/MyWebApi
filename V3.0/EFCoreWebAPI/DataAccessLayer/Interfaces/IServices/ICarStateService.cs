using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface ICarStateService
    {
        int AddCarState(CarState carState);
        void UpdateCarState(CarState carState);
        void DeleteCarState(int Id);
        CarState GetCarStateById(int Id);
        IEnumerable<CarState> GetAllCarStates();
        CarState GetCarStateDetailsById(int Id);
        List<CarState> GetCarStateDetails();
    }
}
