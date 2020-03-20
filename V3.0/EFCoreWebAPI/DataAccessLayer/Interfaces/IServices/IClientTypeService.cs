using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IServices
{
    public interface IClientTypeService
    {
        int AddClientType(ClientType clientType);
        void UpdateClientType(ClientType clientType);
        void DeleteClientType(int Id);
        ClientType GetClientTypeById(int Id);
        IEnumerable<ClientType> GetAllClientTypes();
        ClientType GetClientTypeDetailsById(int Id);
        List<ClientType> GetClientTypeDetails();
    }
}
