using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class ClientTypeRepository : SQLGenericRepository<ClientType>, IClientTypeRepository
    {
        public ClientTypeRepository(SQLDbContext myDBContext) : base(myDBContext) { }
        public async Task<ClientType> GetClientTypeDetailsByIdAsync(int id) =>
            await _myDBContext.ClientTypes
                .Include(c => c.Clients)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        public async Task<List<ClientType>> GetClientTypeDetailsAsync() =>
            await _myDBContext.ClientTypes
                .Include(c => c.Clients)
                .ToListAsync();
        public async Task<string> GetClientTypeByIdAsync(int id) => (await _dbSet.FindAsync(id)).Type;
    }
}