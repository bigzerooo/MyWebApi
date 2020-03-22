using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Services
{
    public class CarHireService : ICarHireService
    {
        IUnitOfWork _unitOfWork;
        public CarHireService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddCarHire(CarHire carHire)
        {
            return _unitOfWork.carHireRepository.Add(carHire);
            //_sqlunitOfWork.Complete();
        }

        public void DeleteCarHire(int Id)
        {
            _unitOfWork.carHireRepository.Delete(Id);
        }

        public IEnumerable<CarHire> GetAllCarHires()
        {
            return _unitOfWork.carHireRepository.GetAll();
        }

        public CarHire GetCarHireById(int Id)
        {
            return _unitOfWork.carHireRepository.Get(Id);
        }

        public void UpdateCarHire(CarHire carHire)
        {
            _unitOfWork.carHireRepository.Update(carHire);
        }
        public CarHire GetCarHireDetailsById(int Id)
        {
            return _unitOfWork.carHireRepository.GetCarHireDetailsById(Id);
        }
        public List<CarHire> GetCarHireDetails()
        {
            return _unitOfWork.carHireRepository.GetCarHireDetails();
        }
    }
}
