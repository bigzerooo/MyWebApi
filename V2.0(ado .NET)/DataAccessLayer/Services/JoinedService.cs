using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Interfaces.IServices;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Entities;
namespace DataAccessLayer.Services
{
    public class JoinedService : IJoinedService
    {
        IUnitOfWork _unitOfWork;
        public JoinedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public int AddJoined(Joined joined)
        {
            return _unitOfWork.joinedRepository.AddJoined(joined);
        }
        public void UpdateJoined(Joined joined)
        {
            _unitOfWork.joinedRepository.UpdateJoined(joined);
        }
        public void DeleteJoined(int Id)
        {
            _unitOfWork.joinedRepository.DeleteJoined(Id);
        }
        public Joined GetJoinedById(int Id)
        {
            return _unitOfWork.joinedRepository.GetJoinedById(Id);
        }
        public IEnumerable<Joined> GetAllJoined()
        {
            return _unitOfWork.joinedRepository.GetAllJoined();
        }
    }
}
