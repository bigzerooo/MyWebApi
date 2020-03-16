using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class ClientTypeRepository : GenericRepository<ClientType, int>, IClientTypeRepository
    {
        public ClientTypeRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
    }
}
