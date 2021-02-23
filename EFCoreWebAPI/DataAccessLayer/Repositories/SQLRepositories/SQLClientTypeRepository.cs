using DataAccessLayer.DbContext;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLClientTypeRepository : SQLGenericRepository<ClientType>, IClientTypeRepository
    {
        public SQLClientTypeRepository(SQLDbContext myDBContext) : base(myDBContext) { }
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