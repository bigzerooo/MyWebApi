using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces.IRepositories
{
    public interface IClientRepository : IGenericRepository<Client, int>
    {
        public Client GetClientDetailsById(int Id);
        public List<Client> GetClientDetails();
    }
}
