using DataAccessLayer.DBContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SpecificRepositories
{
    public class ClientTypeRepository : GenericRepository<ClientType, int>, IClientTypeRepository
    {
        public ClientTypeRepository(MyDBContext myDBContext) : base(myDBContext)
        {


        }
        public async Task<ClientType> GetClientTypeDetailsByIdAsync(int Id)
        {
            var clientType = await _myDBContext.ClientTypes
                .Include(c => c.Clients)
                .Where(c => c.Id == Id)
                .FirstOrDefaultAsync();
            return clientType;
        }
        public async Task<List<ClientType>> GetClientTypeDetailsAsync()
        {
            var clientTypes = await _myDBContext.ClientTypes
                .Include(c => c.Clients)
                .ToListAsync();
            return clientTypes;
        }
    }
}
