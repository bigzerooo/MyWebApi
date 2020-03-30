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
    public class ClientRepository : GenericRepository<Client, int>, IClientRepository
    {
        public ClientRepository(MyDBContext myDBContext) : base(myDBContext)
        {

        }
        public async Task<Client> GetClientDetailsByIdAsync(int Id)
        {
            var client = await _myDBContext.Clients
                .Include(c => c.CarHires)
                .Include(c=>c.ClientType)
                .Where(c => c.Id == Id)
                .FirstOrDefaultAsync();
            return client;
        }
        public async Task<List<Client>> GetClientDetailsAsync()
        {
            var clients = await _myDBContext.Clients
                .Include(c => c.CarHires)
                .Include(c => c.ClientType)
                .ToListAsync();
            return clients;
        }
    }
}
