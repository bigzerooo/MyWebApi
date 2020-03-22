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
    public class ClientTypeRepository : GenericRepository<ClientType, int>, IClientTypeRepository
    {
        public ClientTypeRepository(MyDBContext myDBContext) : base(myDBContext)
        {


        }
        public ClientType GetClientTypeDetailsById(int Id)
        {
            var clientType = _myDBContext.ClientTypes
                .Include(c => c.Clients)
                .Where(c => c.Id == Id)
                .FirstOrDefault();
            return clientType;
        }
        public List<ClientType> GetClientTypeDetails()
        {
            var clientTypes = _myDBContext.ClientTypes
                .Include(c => c.Clients)
                .ToList();
            return clientTypes;
        }
    }
}
