using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IClientTypeRepository : IGenericRepository<ClientType, int>
    {
        public ClientType GetClientTypeDetailsById(int Id);
        public List<ClientType> GetClientTypeDetails();
    }
}
