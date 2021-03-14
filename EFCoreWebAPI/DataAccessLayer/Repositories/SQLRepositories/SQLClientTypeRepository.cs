using DataAccessLayer.DbContext.SQL;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces.Repositories;
using DataAccessLayer.Repositories.GenericRepositories;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.SQLRepositories
{
    public class SQLClientTypeRepository : SQLGenericRepository<ClientType, int>, IClientTypeRepository
    {
        public SQLClientTypeRepository(SQLDbContext myDBContext) : base(myDBContext) { }

        public async Task<string> GetClientTypeStringByIdAsync(int id)
        {
            return (await _dbSet.FindAsync(id)).Type;
        }

        //public async Task<ClientType> GetClientTypeDetailsByIdAsync(int id) =>
        //    await _myDBContext.ClientTypes
        //        .Include(c => c.Clients)
        //        .Where(c => c.Id == id)
        //        .FirstOrDefaultAsync();
        //public async Task<List<ClientType>> GetClientTypeDetailsAsync() =>
        //    await _myDBContext.ClientTypes
        //        .Include(c => c.Clients)
        //        .ToListAsync();
    }
}