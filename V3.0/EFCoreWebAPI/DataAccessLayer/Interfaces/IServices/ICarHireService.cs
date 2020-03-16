using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface ICarHireService
    {
        int AddCarHire(CarHire carHire);
        void UpdateCarHire(CarHire carHire);
        void DeleteCarHire(int Id);
        CarHire GetCarHireById(int Id);
        IEnumerable<CarHire> GetAllCarHires();
    }
}
