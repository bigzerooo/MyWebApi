using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class ClientRepository : GenericRepository<Client, int>, IClientRepository
    {
        public ClientRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
        public Client GetClientDetailsById(int Id)
        {
            var client = _myDBContext.Clients
                .Include(c => c.CarHires)
                .Include(c=>c.ClientType)
                .Where(c => c.Id == Id)
                .FirstOrDefault();
            return client;
        }
        public List<Client> GetClientDetails()
        {
            var clients = _myDBContext.Clients
                .Include(c => c.CarHires)
                .Include(c => c.ClientType)
                .ToList();
            return clients;
        }
    }
}
