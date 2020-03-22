using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Services
{
    public class ClientService : IClientService
    {
        IUnitOfWork _unitOfWork;
        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddClient(Client client)
        {
            return _unitOfWork.clientRepository.Add(client);
            //_sqlunitOfWork.Complete();
        }

        public void DeleteClient(int Id)
        {
            _unitOfWork.clientRepository.Delete(Id);
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _unitOfWork.clientRepository.GetAll();
        }

        public Client GetClientById(int Id)
        {
            return _unitOfWork.clientRepository.Get(Id);
        }

        public void UpdateClient(Client client)
        {
            _unitOfWork.clientRepository.Update(client);
        }

        public Client GetClientDetailsById(int Id)
        {
            return _unitOfWork.clientRepository.GetClientDetailsById(Id);
        }
        public List<Client> GetClientDetails()
        {
            return _unitOfWork.clientRepository.GetClientDetails();
        }
    }
}
