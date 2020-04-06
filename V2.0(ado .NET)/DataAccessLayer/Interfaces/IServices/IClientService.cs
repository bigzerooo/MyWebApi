using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;
namespace DataAccessLayer.Interfaces.IServices
{
    public interface IClientService
    {
        int AddClient(Client client);
        void UpdateClient(Client client);
        void DeleteClient(int Id);
        Client GetClientById(int Id);
        IEnumerable<Client> GetAllClients();
    }
}
