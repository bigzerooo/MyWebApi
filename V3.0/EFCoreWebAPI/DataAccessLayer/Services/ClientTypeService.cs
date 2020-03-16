using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Services
{
    public class ClientTypeService : IClientTypeService
    {
        IUnitOfWork _unitOfWork;
        public ClientTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddClientType(ClientType clientType)
        {
            return _unitOfWork.clientTypeRepository.Add(clientType);
            //_sqlunitOfWork.Complete();
        }

        public void DeleteClientType(int Id)
        {
            _unitOfWork.clientTypeRepository.Delete(Id);
        }

        public IEnumerable<ClientType> GetAllClientTypes()
        {
            return _unitOfWork.clientTypeRepository.GetAll();
        }

        public ClientType GetClientTypeById(int Id)
        {
            return _unitOfWork.clientTypeRepository.Get(Id);
        }

        public void UpdateClientType(ClientType clientType)
        {
            _unitOfWork.clientTypeRepository.Update(clientType);
        }
    }
}
